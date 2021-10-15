using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class EscrowDecision
    {
        public long DbId { get; set; }
        public long EscrowId { get; set; }
        public long AccountId { get; set; }
        public int Decision { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
