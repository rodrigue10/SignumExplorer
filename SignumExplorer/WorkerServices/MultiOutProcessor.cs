using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using static MudBlazor.FilterOperator;

namespace SignumExplorer
{
    public class MultiOutProcessor : BackgroundService
    {
        private int UpdateTime { get; set; } = 300;
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


                    //Creatively break up the delay and check for cancellation token so the service can be managed via web UI
                    for (int i = 0; i < 500; i++)
                    {
                        if (!stoppingToken.IsCancellationRequested)
                        {
                            await Task.Delay(TimeSpan.FromMinutes((double)UpdateTime / 500), stoppingToken);
                        }
                        else
                        {
                            break;
                        }
                    }



                   // await Task.Delay(60000);
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