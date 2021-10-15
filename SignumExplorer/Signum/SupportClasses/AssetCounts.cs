namespace SignumExplorer.Models
{
    public class AssetCounts
    {

        

        public int Holders { get; set; }
        public int Trades { get; set; }

        public int Transfers {  get; set; }

        public int OpenAsksOrders { get; set; }
        public int OpenBidsOrders { get; set; }

        public int TotalOpenOrders => OpenAsksOrders + OpenBidsOrders;




    }
}
