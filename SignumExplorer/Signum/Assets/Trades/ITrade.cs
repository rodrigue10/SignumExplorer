using System;

namespace SignumExplorer.Models
{
    public interface ITrade
    {
        public ulong AssetId { get; }
        public ulong BlockId { get; }
        public ulong AskOrderId { get; }
        public ulong BidOrderId { get; }
        public int AskOrderHeight { get; }
        public int BidOrderHeight { get; }
        public ulong SellerId { get; }
        public ulong BuyerId { get; }
        public ulong Quantity { get; }
        public ulong Price { get; }
        public int Timestamp { get; }
        public int Height { get; }

        public DateTime Time { get; }
        public DateTime Date => Time.Date;

        public string SellerRS => ReedSolomon.encode(SellerId);
        public string BuyerRS => ReedSolomon.encode(BuyerId);

        public ulong? AssetQuantity { get;  }
        public sbyte? Decimals { get; }

        public string? AssetName { get;  }

    }
}
