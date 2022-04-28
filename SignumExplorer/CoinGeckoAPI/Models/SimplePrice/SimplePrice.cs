using System.Text.Json.Serialization;

namespace SignumExplorer.CoinGeckoAPI.Models
{

    public class SimplePrice : ISimplePrice
    {
        [JsonPropertyName("signum")]
        public SimplePriceSignum? Signum { get; set; }
        ISimplePriceSignum? ISimplePrice.Signum => Signum;
    }

    public interface ISimplePrice
    {
        [JsonPropertyName("signum")]
        public ISimplePriceSignum? Signum { get;  }
    }

}
