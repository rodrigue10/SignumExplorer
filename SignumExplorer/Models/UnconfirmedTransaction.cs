using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class UnconfirmedTransaction
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public int Expiration { get; set; }
        public int TransactionHeight { get; set; }
        public long FeePerByte { get; set; }
        public int Timestamp { get; set; }
        public byte[] TransactionBytes { get; set; } = null!;
        public int Height { get; set; }
    }
}
