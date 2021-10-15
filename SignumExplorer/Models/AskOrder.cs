using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AskOrder
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long AssetId { get; set; }
        public long Price { get; set; }
        public long Quantity { get; set; }
        public int CreationHeight { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
