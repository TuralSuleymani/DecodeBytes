
using Confluent.Kafka;
using Microsoft.OpenApi.Validations;

namespace HostedServiceApp.Services
{
    public class ConsumerServiceOld(ILogger<ConsumerService> logger) : IHostedService
    {
        private ILogger<ConsumerService> _logger = logger;
        private Task _task;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "mybgGroup",
                ClientId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _task = Task.Factory.StartNew(() =>
            {
                using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
                {
                    consumer.Subscribe("employeeTopic");
                    while (!cancellationToken.IsCancellationRequested)
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
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }



    public class ConsumerService(ILogger<ConsumerService> logger) : BackgroundService
    {
        private ILogger<ConsumerService> _logger = logger;

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "randomgroupId",
                ClientId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            return Task.Factory.StartNew(() =>
            {
                using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
                {
                    consumer.Subscribe("employeeTopic");
                    while (!cancellationToken.IsCancellationRequested)
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
            }, cancellationToken);

        }
    }
}
