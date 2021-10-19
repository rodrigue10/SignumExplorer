using System;

namespace SignumExplorer.Models
{
    public interface ITransaction
    {
        public string TransactionType
            {
                 get {
                         var type = TransactionTypes.TransactionDescription(Type, Subtype);

                            return type == null ? string.Empty : type;
                     }

             }
        public ulong Id { get; }
        public short Deadline { get;  }
        public string SenderPublicKey { get; }
        public ulong? RecipientId { get;  }
        public double Amount { get;  }
        public double Fee { get;  }
        public int Height { get;  }
        public ulong BlockId { get;  }
        public string? Signature { get;  }
        public int Timestamp { get; }
        public sbyte Type { get; }
        public sbyte Subtype { get;  }
        public ulong SenderId { get; }
        public int BlockTimestamp { get;}
        public string FullHash { get; }
        public string? ReferencedTransactionFullhash { get;  }
        public string? AttachmentBytes { get; }
        public sbyte Version { get;  }
        public bool HasMessage { get;  }
        public bool HasEncryptedMessage { get;  }
        public bool HasPublicKeyAnnouncement { get; }
        public int? EcBlockHeight { get;  }
        public ulong? EcBlockId { get;  }
        public bool HasEncrypttoselfMessage { get;  }

        public abstract IBlock Block { get; }

        public DateTime Time {  get; }

        public string SenderRS => ReedSolomon.encode(SenderId);
        public string RecipientRS => ReedSolomon.encode(RecipientId.Value);


    }
}
