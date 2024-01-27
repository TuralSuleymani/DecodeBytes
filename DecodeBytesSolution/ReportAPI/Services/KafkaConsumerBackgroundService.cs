using Confluent.Kafka;
using ReportAPI.Database;
using ReportAPI.Models;
using System.Text.Json;

namespace ReportAPI.Services
{
    public class KafkaConsumerBackgroundService : BackgroundService
    {
        private ReportDbContext _reportDbContext;
        public KafkaConsumerBackgroundService(ReportDbContext reportDbContext)
        {
            _reportDbContext = reportDbContext;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "myReportConsumerGroup",
                ClientId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("employeeTopic");
                while(!cancellationToken.IsCancellationRequested)
                {
                    var consumedData = consumer.Consume(TimeSpan.FromSeconds(3));
                    if (consumedData is not null)
                    {
                        var employee = JsonSerializer.Deserialize<Employee>(consumedData.Value);
                        EmployeeReport er = new EmployeeReport(Guid.NewGuid(), employee.Id, employee.Name, employee.Surname);
                        _reportDbContext.Reports.Add(er);
                        await _reportDbContext.SaveChangesAsync();
                    }
                }
                
            }
        }
    }
}
