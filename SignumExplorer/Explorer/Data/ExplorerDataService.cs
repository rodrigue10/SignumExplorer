using Microsoft.EntityFrameworkCore;
using SignumExplorer.Context;
using SignumExplorer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignumExplorer.Data
{
    public class ExplorerDataService : IExplorerDataService
    {


        private readonly IDbContextFactory<ExplorerContext> _contextFactory;

        public ExplorerDataService(IDbContextFactory<ExplorerContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

            public async Task<bool> DeleteAllCoinGeckoAsync()
            {
                using (var context = _contextFactory.CreateDbContext())
                {

                    context.CoinGeckos.RemoveRange(context.CoinGeckos);                
             
                    await context.SaveChangesAsync();
                    return true;



                }
            }
        public async Task<CoinGecko> GetCoinGeckoData()
        {
            using (var context = _contextFactory.CreateDbContext())
            {                            

                var coinGecko = await context.CoinGeckos.FirstOrDefaultAsync();

                if (  coinGecko != null )
                {
                    return coinGecko;
                }
                else
                {
                    return new CoinGecko();
                }
                             


            }

        }
        public async Task<CoinGecko> GetLatestCoinGeckoData()
        {
            using (var context = _contextFactory.CreateDbContext())
            {

                var coinGecko = await context.CoinGeckos.OrderBy(e => e.DbId).LastAsync();

                if (coinGecko != null)
                {
                    return coinGecko;
                }
                else
                {
                    return new CoinGecko();
                }



            }

        }


        public async Task<CoinGecko> UpdateCoinGeckoAsync(CoinGecko coinGecko)
        {
            if (coinGecko == null)
            {
                throw new ArgumentNullException(nameof(coinGecko));
            }

            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.CoinGeckos.Update(coinGecko);
                    await context.SaveChangesAsync();
                    return coinGecko;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(coinGecko)} could not be updated: {ex.Message}");
            }
        }

        public async Task<CoinGecko> AddCoinGeckoAsync(CoinGecko coinGecko)
        {
            if (coinGecko == null)
            {
                throw new ArgumentNullException(nameof(coinGecko));
            }

            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                   
                    context.CoinGeckos.Add(coinGecko);
                    await context.SaveChangesAsync();
                    return coinGecko;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(coinGecko)} could not be updated: {ex.Message}");
            }
        }



    }


}
