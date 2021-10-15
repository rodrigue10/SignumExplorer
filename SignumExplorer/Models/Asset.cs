using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Asset
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public long Quantity { get; set; }
        public sbyte Decimals { get; set; }
        public int Height { get; set; }
    }
}
