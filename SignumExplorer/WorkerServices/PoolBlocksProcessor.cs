using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignumExplorer.Context;
using SignumExplorer.Data;
using SignumExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignumExplorer
{
    public class PoolBlocksProcessor : BackgroundService
    {
        //Setup some defaults in case appsettings have issues.
        private int UpdateTime { get; set; } = 240;
        private int UpdateSize { get; set; } = 1000;
        private int BlockLag { get; set; } = 2;

        //Used to help monitor and control service from web-page
        public bool IsRunning { get; set; }
  

        private readonly ILogger<PoolBlocksProcessor> _logger;
        private readonly IConfiguration _configuration;
        private readonly IDbContextFactory<ExplorerContext> _contextFactoryExplorer;
        private readonly IDbContextFactory<signumContext> _contextFactorySignum;

        public PoolBlocksProcessor(IConfiguration configuration, ILogger<PoolBlocksProcessor>  logger, 
                                    IDbContextFactory<signumContext> contextFactorySignum,
                                    IDbContextFactory<ExplorerContext> contextFactoryExplorer)
                                    {
                                        _contextFactoryExplorer = contextFactoryExplorer;
                                        _contextFactorySignum = contextFactorySignum;
                                        _configuration = configuration;
                                        _logger = logger;

                                    }
        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                if (int.TryParse(_configuration["PoolBlocksProcessor:UpdateInterval"], out int updateTime))
                {
                    UpdateTime = updateTime;
                }
                if (int.TryParse(_configuration["PoolBlocksProcessor:UpdateSize"],out int updateSize))
                {
                    UpdateSize = updateSize;
                }
                if (int.TryParse(_configuration["PoolBlocksProcessor:BlockLag"], out int blockLag))
                {
                    BlockLag = blockLag;
                }


                _logger.LogInformation($"{nameof(PoolBlocksProcessor)} starting {nameof(ExecuteAsync)}");

                IsRunning = true;

                while (!stoppingToken.IsCancellationRequested)
                {
                    using (var contextSignum = _contextFactorySignum.CreateDbContext())
                    using (var contextExplorer = _contextFactoryExplorer.CreateDbContext())
                    {
                            List<BlockPoolWon> SignumQueryResult = new();

                            int? resultSignum = await contextSignum.BlockPoolWons.MaxAsync(e => e.Height);                                            

                            //Get max from explorer database to determine its state
                            int? resultExplorer = await contextExplorer.PoolWonBlocks.MaxAsync(e => e.Height);

                            if (resultSignum.Value - resultExplorer.Value < 0)
                            {
                                contextExplorer.RemoveRange(contextExplorer.PoolWonBlocks);
                            }


                            if (resultExplorer == null)
                            {
                                SignumQueryResult = await contextSignum.BlockPoolWons.OrderBy(e => e.Height).Take(UpdateSize-BlockLag).ToListAsync();
                            }
                            else
                            {     
                                SignumQueryResult = await contextSignum.BlockPoolWons.OrderBy(e => e.Height).Skip(resultExplorer.Value + 1).Take(UpdateSize - BlockLag).ToListAsync();

                            }

                        List<PoolWonBlock> converted = ConvertSignumToExplorer(SignumQueryResult);

                        await contextExplorer.PoolWonBlocks.AddRangeAsync(converted);
                        await contextExplorer.SaveChangesAsync();

                    }

                        _logger.LogInformation($"{nameof(PoolBlocksProcessor)} running {nameof(ExecuteAsync)}");

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
                  //  await Task.Delay(TimeSpan.FromSeconds(UpdateTime));
                }
                IsRunning = false;
                _logger.LogInformation($"{nameof(PoolBlocksProcessor)} ending {nameof(ExecuteAsync)}");
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

        private List<PoolWonBlock> ConvertSignumToExplorer(List<BlockPoolWon> signumQueryResult)
        {
            List<PoolWonBlock> result = new List<PoolWonBlock>();

            foreach (var item in signumQueryResult)
            {
                PoolWonBlock poolWonBlock = new PoolWonBlock()
                {
                    Height = item.Height,
                    GeneratorId = item.GeneratorId,
                    PoolId = item.PoolId,
                };
                
                result.Add(poolWonBlock);

            }
            return result;
        }
    }
}