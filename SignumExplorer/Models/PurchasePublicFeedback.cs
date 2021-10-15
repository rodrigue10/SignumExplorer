using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class PurchasePublicFeedback
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public string PublicFeedback { get; set; } = null!;
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
