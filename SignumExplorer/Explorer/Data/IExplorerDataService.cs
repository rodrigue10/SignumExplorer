using SignumExplorer.Models;
using System.Threading.Tasks;

namespace SignumExplorer.Data
{
    public interface IExplorerDataService
    {
        public Task<CoinGecko> GetCoinGeckoData();

        public Task<CoinGecko> UpdateCoinGeckoAsync(CoinGecko coinGecko);
        public Task<CoinGecko> AddCoinGeckoAsync(CoinGecko coinGecko);

        Task<bool> DeleteAllCoinGeckoAsync();

    }

}