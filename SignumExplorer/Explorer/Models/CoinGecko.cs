namespace SignumExplorer.Models
{
    public class CoinGecko :  ICoinGecko
    {
            public long DbId { get; set; }
            public double Btc { get; set; }       
            public double BtcMarketCap { get; set; }     
            public double Btc24hVol { get; set; }  
            public double Btc24hChange { get; set; }       
            public double Usd { get; set; }   
            public double UsdMarketCap { get; set; }
            public double Usd24hVol { get; set; }     
            public double Usd24hChange { get; set; } 
            public int LastUpdatedAt { get; set; }
       


    }

    public interface ICoinGecko
    {
        public double Btc { get; }
        public double BtcMarketCap { get; }
        public double Btc24hVol { get; }
        public double Btc24hChange { get; }
        public double Usd { get; }
        public double UsdMarketCap { get; }
        public double Usd24hVol { get; }
        public double Usd24hChange { get; }
        public int LastUpdatedAt { get; }
    }
}
