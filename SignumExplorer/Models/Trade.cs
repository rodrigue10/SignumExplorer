using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Trade
    {
        public long DbId { get; set; }
        public long AssetId { get; set; }
        public long BlockId { get; set; }
        public long AskOrderId { get; set; }
        public long BidOrderId { get; set; }
        public int AskOrderHeight { get; set; }
        public int BidOrderHeight { get; set; }
        public long SellerId { get; set; }
        public long BuyerId { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public int Timestamp { get; set; }
        public int Height { get; set; }
    }
}
