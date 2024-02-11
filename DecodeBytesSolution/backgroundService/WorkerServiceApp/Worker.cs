using Confluent.Kafka;
using System.Threading;

namespace WorkerServiceApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "qwertyGroupId",
                ClientId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
                {
                    consumer.Subscribe("employeeTopic");
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var consumedData = consumer.Consume(TimeSpan.FromSeconds(5));
                        if (consumedData != null)
                        {
                            _logger.LogInformation($"Received Data {consumedData.Message.Value}", consumedData.Message.Value);
                        }
                        else
                            _logger.LogInformation("No data to consume");
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}
