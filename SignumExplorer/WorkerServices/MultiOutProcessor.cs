using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignumExplorer
{
    public class MultiOutProcessor : BackgroundService
    {

        public bool IsRunning { get; set; }

        private readonly ILogger<MultiOutProcessor> _logger;

        public MultiOutProcessor(ILogger<MultiOutProcessor> logger) =>
            _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation($"{nameof(MultiOutProcessor)} starting {nameof(ExecuteAsync)}");
                IsRunning = true;
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"{nameof(MultiOutProcessor)} running {nameof(ExecuteAsync)}");




                    await Task.Delay(60000);
                }
                IsRunning = false;
                _logger.LogInformation($"{nameof(MultiOutProcessor)} ending {nameof(ExecuteAsync)}");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
            }
            finally
            {
                IsRunning = false;
            }
        }




    }
}