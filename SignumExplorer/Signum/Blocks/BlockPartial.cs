
using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public partial class Block : IBlock
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
        double IBlock.TotalFee => TotalFee/ 100000000.0;

        ulong? IBlock.PreviousBlockId { get
        {
                if (PreviousBlockId != null)
                {
                    return (ulong)PreviousBlockId;
                  }
                else return 0;

            } } 

        ulong IBlock.BaseTarget => (ulong)BaseTarget;

        ulong? IBlock.NextBlockId { get
            {
                if (NextBlockId != null)
                {
                    return (ulong)NextBlockId;
                } 
                else return 0;

            } } 

        ulong IBlock.Nonce => (ulong)Nonce;

        ICollection<ITransaction> IBlock.Transactions { get
            {
                var hash = new HashSet<ITransaction>();
                foreach(var item in Transactions)
                {
                    hash.Add(item);
                }

                return hash;
            } 
        }

        //Not able to implement directly from Block Table....this is used for view/table interface compatibility
        public string? Name => null;

        public ulong? RecipId => null;

        public string? RecipName => null;

        public ulong? TransactionCount => null;
    }
}
