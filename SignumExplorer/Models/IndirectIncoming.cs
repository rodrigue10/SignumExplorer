using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class IndirectIncoming
    {
        public long DbId { get; set; }
        public long AccountId { get; set; }
        public long TransactionId { get; set; }
        public int Height { get; set; }
    }
}
