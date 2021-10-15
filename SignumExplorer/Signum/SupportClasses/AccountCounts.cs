namespace SignumExplorer.Models
{
    public class AccountCounts
    {

        public int SingleTrans {  get; set; }
        public int MultiTrans {  get; set; }
        public int AllTrans {  get; set; }
        public int ForgedBlocks {  get; set; }

        public int AssetTransfers {  get; set; }

        public int AssetTrades {  get; set;}
        public int AssetHoldings { get; set; }

        public int AssetTotalOrders {  get; set;}
        
        public int AssetAsks {  get; set; }
        public int AssetBids {  get; set; }

        public int Aliases {  get; set; }

        public int AliasOffers {  get; set; }

        public int TotalOrders => AssetAsks + AssetBids;

        public int PoolMembers { get; set; }

        public int Ats { get; set; }
    }
}
