using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AccountAsset
    {
        public long DbId { get; set; }
        public long AccountId { get; set; }
        public long AssetId { get; set; }
        public long Quantity { get; set; }
        public long UnconfirmedQuantity { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
