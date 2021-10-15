using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class BlockRewardRecipDesc
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public int Version { get; set; }
        public int Timestamp { get; set; }
        public long? PreviousBlockId { get; set; }
        public long TotalAmount { get; set; }
        public long TotalFee { get; set; }
        public int PayloadLength { get; set; }
        public byte[] GeneratorPublicKey { get; set; } = null!;
        public byte[]? PreviousBlockHash { get; set; }
        public byte[] CumulativeDifficulty { get; set; } = null!;
        public long BaseTarget { get; set; }
        public long? NextBlockId { get; set; }
        public int Height { get; set; }
        public byte[] GenerationSignature { get; set; } = null!;
        public byte[] BlockSignature { get; set; } = null!;
        public byte[] PayloadHash { get; set; } = null!;
        public long GeneratorId { get; set; }
        public long Nonce { get; set; }
        public byte[]? Ats { get; set; }
        public string? Name { get; set; }
        public long? RecipId { get; set; }
        public string? RecipName { get; set; }
        public long? TransactionCount { get; set; }
    }
}
