using Confluent.Kafka;
using Consumer.Database.Entities;
using Consumer.Database.ReportAPI.Database;
using Consumer.Shared;
using System.Text.Json;

namespace ConsumerService
{
    public class Worker(ReportDbContext reportDbContext
            , ILogger<Worker> logger) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly ReportDbContext _reportDbContext = reportDbContext;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "myReportConsumerGroup2",
                ClientId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
            consumer.Subscribe("employeeTopic");
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumedData = consumer.Consume(TimeSpan.FromSeconds(3));
                if (consumedData is not null)
                {

                    var employee = JsonSerializer.Deserialize<Employee>(consumedData.Message.Value);
                    _logger.LogInformation($"Consuming {employee}");
                    EmployeeReport er = new(Guid.NewGuid(), employee.Id, employee.Name, employee.Surname);
                    _reportDbContext.Reports.Add(er);
                    await _reportDbContext.SaveChangesAsync();
                }
                else
                    _logger.LogInformation("Nothing found to consume");
               // await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
