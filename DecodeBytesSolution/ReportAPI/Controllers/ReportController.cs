using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

public abstract class MyService : IHostedService, IDisposable
{
    public abstract Task RunAsync(CancellationToken cancellationToken);
    private Task _runningTask;
    private readonly CancellationTokenSource _stoppingCts =
                                                   new CancellationTokenSource();
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _runningTask = RunAsync(_stoppingCts.Token);
        if (_runningTask.IsCompleted)
        {
            return _runningTask;
        }
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        // Stop called without start
        if (_runningTask == null)
        {
            return;
        }

        try
        {
            // Signal cancellation to the executing method
            _stoppingCts.Cancel();
        }
        finally
        {
            // Wait until the task completes or the stop token triggers
            await Task.WhenAny(_runningTask, Task.Delay(Timeout.Infinite,
                                                          cancellationToken));
        }
    }

    public void Dispose()
    {
        _stoppingCts.Cancel();
    }
}

public class KafkaService : MyService
{
    public override Task RunAsync(CancellationToken cancellationToken)
    {
        var config = new ConsumerConfig()
        {
            BootstrapServers = "localhost:9092",
            GroupId = "ds"
        };
        using (var consumer = new ConsumerBuilder<string, string>(config).Build())
        {
            consumer.Subscribe("employeetopic");
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResponse = consumer.Consume(TimeSpan.FromSeconds(2));
                if (consumeResponse != null)
                {
                    //add to be
                }
            }
        }
        return Task.CompletedTask;
    }
}

namespace ReportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }
        //start and stop

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "test";
        }
    }
}
