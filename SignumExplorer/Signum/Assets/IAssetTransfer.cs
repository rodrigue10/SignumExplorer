using System;

namespace SignumExplorer.Models
{
    public interface IAssetTransfer
    {
        public ulong Id { get; }
        public ulong AssetId { get;  }
        public ulong SenderId { get;  }
        public ulong RecipientId { get;  }
        public ulong Quantity { get;  }
        public int Timestamp { get;  }
        public int Height { get; }

        public DateTime Time {  get; }

        public string SenderRS => ReedSolomon.encode(SenderId);
        public string RecipientRS => ReedSolomon.encode(RecipientId);

        public ulong? AssetQuantity { get; }
        public sbyte? Decimals { get; }

        public string? AssetName { get; }
    }
}
