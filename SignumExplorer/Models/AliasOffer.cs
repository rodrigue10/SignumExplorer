using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AliasOffer
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long Price { get; set; }
        public long? BuyerId { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
