using System;

namespace SignumExplorer.Signum
{
    public class TradeData
    {
        public int Height {  get; set; }
        public DateTime  Date {  get; set; }
        public double Volume {  get; set; }

        public double Average {  get; set; }

        public int Findcount {  get; set; }

        public double Maxprice { get; set; }
        public double Minprice {  get; set; }

    }
}
