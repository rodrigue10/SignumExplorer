using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class BlockRewardRecipDesc : IBlock
    {
        


        public DateTime Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);

        public string GeneratorPublicKeyString => BitConverter.ToString(GeneratorPublicKey).Replace("-", "");

        public string PreviousBlockHashString

        {
            get
            {

                if (PreviousBlockHash != null)
                {
                    return BitConverter.ToString(PreviousBlockHash).Replace("-", "");
                }
                else return string.Empty;
            }
        }

        public string CumulativeDifficultyString => BitConverter.ToString(CumulativeDifficulty).Replace("-", "");

        public string GenerationSignatureString => BitConverter.ToString(GenerationSignature).Replace("-", "");

        public string BlockSignatureString => BitConverter.ToString(BlockSignature).Replace("-", "");

        public string PayloadHashString => BitConverter.ToString(PayloadHash).Replace("-", "");
        public string AtsString

        {
            get
            {
                if (Ats != null)
                {
                    return BitConverter.ToString(Ats).Replace("-", "");
                }
                else return "";
            }
        }


        ulong IBlock.Id => (ulong)Id;

        ulong IBlock.GeneratorId => (ulong)GeneratorId;

        double IBlock.TotalAmount => TotalAmount / 100000000.0;
        double IBlock.TotalFee => TotalFee / 100000000.0;

        ulong? IBlock.PreviousBlockId
        {
            get
            {
                if (PreviousBlockId != null)
                {
                    return (ulong)PreviousBlockId;
                }
                else return 0;

            }
        }

        ulong IBlock.BaseTarget => (ulong)BaseTarget;

        ulong? IBlock.NextBlockId
        {
            get
            {
                if (NextBlockId != null)
                {
                    return (ulong)NextBlockId;
                }
                else return 0;

            }
        }


        ulong IBlock.Nonce => (ulong)Nonce;

        ulong? IBlock.RecipId
        {
           get
            {
            if (RecipId != null)
            {
                return (ulong)RecipId;
            }
                else return 0;

        }

        }
             
      

        ulong? IBlock.TransactionCount
        {
            get
            {
                if (TransactionCount != null)
                {
                    return (ulong)TransactionCount;
                }
                else return 0;

            }

        }


        //Not able to implement this via this View.
        public ICollection<ITransaction>? Transactions => null;

        string IBlock.Name
        {
            get
            {
                if (Name != null) return this.Name;
                else return "(empty)";
            }
        }

    }
}
