using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AssetTransfer
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long AssetId { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
        public long Quantity { get; set; }
        public int Timestamp { get; set; }
        public int Height { get; set; }
    }
}
