using System.Text.Json.Serialization;

namespace SignumExplorer.CoinGeckoAPI.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class SimplePriceSignum : ISimplePriceSignum
    {
        [JsonPropertyName("btc")]
        public double Btc { get; set; }

        [JsonPropertyName("btc_market_cap")]
        public double BtcMarketCap { get; set; }

        [JsonPropertyName("btc_24h_vol")]
        public double Btc24hVol { get; set; }

        [JsonPropertyName("btc_24h_change")]
        public double Btc24hChange { get; set; }

        [JsonPropertyName("usd")]
        public double Usd { get; set; }

        [JsonPropertyName("usd_market_cap")]
        public double UsdMarketCap { get; set; }

        [JsonPropertyName("usd_24h_vol")]
        public double Usd24hVol { get; set; }

        [JsonPropertyName("usd_24h_change")]
        public double Usd24hChange { get; set; }

        [JsonPropertyName("last_updated_at")]
        public int LastUpdatedAt { get; set; }
    }

    public interface ISimplePriceSignum
    {
        public double Btc { get;  }
        public double BtcMarketCap { get;  }
        public double Btc24hVol { get;  }   
        public double Btc24hChange { get;  }     
        public double Usd { get;  }
        public double UsdMarketCap { get; }
        public double Usd24hVol { get;}  
        public double Usd24hChange { get; }
        public int LastUpdatedAt { get; }
    }


}
