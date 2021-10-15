using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Good
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long SellerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public int Timestamp { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public bool Delisted { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
