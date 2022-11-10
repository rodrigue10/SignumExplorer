using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Transaction
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public short Deadline { get; set; }
        public byte[] SenderPublicKey { get; set; } = null!;
        public long? RecipientId { get; set; }
        public long Amount { get; set; }
        public long Fee { get; set; }
        public int Height { get; set; }
        public long BlockId { get; set; }
        public byte[]? Signature { get; set; }
        public int Timestamp { get; set; }
        public sbyte Type { get; set; }
        public sbyte Subtype { get; set; }
        public long SenderId { get; set; }
        public int BlockTimestamp { get; set; }
        public byte[] FullHash { get; set; } = null!;
        public byte[]? ReferencedTransactionFullhash { get; set; }
        public byte[]? AttachmentBytes { get; set; }
        public sbyte Version { get; set; }
        public bool HasMessage { get; set; }
        public bool HasEncryptedMessage { get; set; }
        public bool HasPublicKeyAnnouncement { get; set; }
        public int? EcBlockHeight { get; set; }
        public long? EcBlockId { get; set; }
        public bool HasEncrypttoselfMessage { get; set; }
        public long? CashBackId { get; set; }

        public virtual Block Block { get; set; } = null!;
    }
}
