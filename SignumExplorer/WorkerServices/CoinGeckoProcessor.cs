using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignumExplorer.CoinGeckoAPI.Services;
using SignumExplorer.Context;
using SignumExplorer.Data;
using SignumExplorer.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignumExplorer
{
    public class CoinGeckoProcessor : BackgroundService
    {

        private int UpdateTime { get; set; } = 30;
        private int RetainRows { get; set; } = 100;
        public bool IsRunning { get; set; }


        private readonly IConfiguration _configuration;
        private readonly ILogger<CoinGeckoProcessor> _logger;
        private readonly ICoinGeckoAPIService _coinGeckoAPIService;
        private readonly IDbContextFactory<ExplorerContext> _contextFactoryExplorer;

        public CoinGeckoProcessor(IConfiguration configuration, ILogger<CoinGeckoProcessor>  logger, ICoinGeckoAPIService coinGeckoAPIService, IDbContextFactory<ExplorerContext> contextFactoryExplorer)
        {
            _configuration = configuration;
            _logger = logger;
            _coinGeckoAPIService = coinGeckoAPIService;
            _contextFactoryExplorer = contextFactoryExplorer;

        }
        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                                 
               if( int.TryParse(_configuration["CoinGeckoProcessor:UpdateInterval"], out int updateTime))
                {
                    UpdateTime = updateTime;
                }
                if (int.TryParse(_configuration["CoinGeckoProcessor:RetainRows"], out int retainRows))
                {
                    RetainRows = retainRows;
                }




                _logger.LogInformation($"{nameof(CoinGeckoProcessor)} starting {nameof(ExecuteAsync)}");

                IsRunning = true;

                while (!stoppingToken.IsCancellationRequested)
                {
                    
                        //Attempt to get an updated CoinGecko Dataset
                        var coin = await _coinGeckoAPIService.GetSimplePrice();

                        if (coin != null)
                        {
                            if (coin.Signum != null)
                            {
                                _logger.LogInformation($"{nameof(CoinGeckoProcessor)} API Call success {nameof(ExecuteAsync)}");


                                CoinGecko coinGecko = new()
                                {
                                    Btc = coin.Signum.Btc,
                                    Btc24hChange = coin.Signum.Btc24hChange,
                                    Btc24hVol = coin.Signum.Btc24hVol,
                                    BtcMarketCap = coin.Signum.BtcMarketCap,
                                    LastUpdatedAt = coin.Signum.LastUpdatedAt,
                                    Usd = coin.Signum.Usd,
                                    Usd24hChange = coin.Signum.Usd24hChange,
                                    Usd24hVol = coin.Signum.Usd24hVol,
                                    UsdMarketCap = coin.Signum.UsdMarketCap
                                };



                            using var contextExplorer = _contextFactoryExplorer.CreateDbContext();
                            var counts = await contextExplorer.CoinGeckos.CountAsync(stoppingToken);
                            if (counts > RetainRows)
                            {
                                var remove = await contextExplorer.CoinGeckos.OrderByDescending(h => h.DbId).Skip(RetainRows).ToListAsync(cancellationToken: stoppingToken);
                                contextExplorer.CoinGeckos.RemoveRange(remove);
                            }


                            await contextExplorer.CoinGeckos.AddAsync(coinGecko, stoppingToken);

                            await contextExplorer.SaveChangesAsync(stoppingToken);
                            _logger.LogInformation($"{nameof(CoinGeckoProcessor)} Added Data to Explorer {nameof(ExecuteAsync)}");



                        }
                        } 

                    _logger.LogInformation($"{nameof(CoinGeckoProcessor)} running {nameof(ExecuteAsync)}");


                    //Creatively break up the delay and check for cancellation token so the service can be managed via web UI
                    for (int i = 0; i < 500; i++)
                    {
                        if (!stoppingToken.IsCancellationRequested)
                        {
                            await Task.Delay(TimeSpan.FromMinutes((double)UpdateTime/500), stoppingToken);
                        }
                        else
                        {
                            break;
                        }
                    }

                    
                }

                IsRunning = false;
                _logger.LogInformation($"{nameof(CoinGeckoProcessor)} ending {nameof(ExecuteAsync)}");
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"Couldn't Parse configuration parameters");
               
            }
            finally
            {
                IsRunning = false;
            }
        }




    }
}