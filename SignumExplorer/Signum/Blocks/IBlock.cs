
using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public interface IBlock
    {
        public ulong Id { get; }
        public int Version { get; }
        public int Timestamp { get; }
        public DateTime Time { get; }
        public ulong? PreviousBlockId { get;  }
        public double TotalAmount { get; }
        public double TotalFee { get; }
        public int PayloadLength { get;  }
        public string GeneratorPublicKeyString { get; }
        public string PreviousBlockHashString {  get; }          
        public string CumulativeDifficultyString {  get; }        
        public ulong BaseTarget { get;  }
        public ulong? NextBlockId { get;  }
        public int Height { get;  }
        public string GenerationSignatureString {  get; }
        public string BlockSignatureString {  get; }
        public string PayloadHashString {  get; }
        public ulong GeneratorId { get; }
        public ulong Nonce { get; }
        public string AtsString { get; }

        public  ICollection<ITransaction>? Transactions { get; }

        public string GeneratorRS => ReedSolomon.encode(GeneratorId);


        public string Name { get; }
        public ulong? RecipId { get; }
        public string? RecipName { get; }
        public ulong? TransactionCount { get; }

        public string RecipientRS
        {

            get
            {
                if (RecipId != null)
                {
                    return ReedSolomon.encode(RecipId.Value);
                }
                else
                {

                    return "";
                }
            }

        }

    }


}
