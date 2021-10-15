using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class PurchaseFeedback
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public byte[] FeedbackData { get; set; } = null!;
        public byte[] FeedbackNonce { get; set; } = null!;
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
