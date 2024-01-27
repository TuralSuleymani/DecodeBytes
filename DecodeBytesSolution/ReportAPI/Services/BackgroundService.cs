
namespace ReportAPI.Services
{
    public abstract class BackgroundService : IHostedService, IDisposable
    {
        protected abstract Task ExecuteAsync(CancellationToken cancellationToken);
        private CancellationTokenSource _consumerTokenSource = new CancellationTokenSource();
        private Task _consumerAsync;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _consumerAsync = ExecuteAsync(_consumerTokenSource.Token);
            if (!_consumerAsync.IsCompleted)
                return _consumerAsync;
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_consumerAsync is null)
                return;
            try
            {
                _consumerTokenSource.Cancel();
            }
            finally
            {
               await Task.WhenAny(_consumerAsync);
            }
        }
        public void Dispose()
        {
            _consumerTokenSource.Cancel();
        }
    }
}
