using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{


    public partial class Transaction : ITransaction
    {
 

        string ITransaction.SenderPublicKey => BitConverter.ToString(SenderPublicKey).Replace("-", "");

        ulong ITransaction.Id => (ulong)Id;

        ulong ITransaction.RecipientId
        {

            get
            {
                return (RecipientId != null) ? (ulong)RecipientId : ulong.MinValue;

            }
        }

        ulong ITransaction.BlockId => (ulong)BlockId;

        ulong ITransaction.SenderId => (ulong)SenderId;

        ulong? ITransaction.EcBlockId
        {
            get
            {
                if (EcBlockId != null)
                { return (ulong)EcBlockId; }
                else
                    return new ulong();
            }
        }
        

        string? ITransaction.Signature
        {
            get
            {
                            if (Signature != null)
                { return BitConverter.ToString(Signature).Replace("-", ""); }
    
                else
                return "";

            }   
        }
            

        string ITransaction.FullHash => BitConverter.ToString(FullHash).Replace("-", "");

        string? ITransaction.ReferencedTransactionFullhash
        {
            get
            {
                if (ReferencedTransactionFullhash != null)
                { return BitConverter.ToString(ReferencedTransactionFullhash).Replace("-", ""); }

                else
                    return "";

            }
        }

        string? ITransaction.AttachmentBytes
        {
            get
            {
                if (AttachmentBytes != null)
                { return BitConverter.ToString(AttachmentBytes).Replace("-", ""); }

                else
                    return "";

            }
        }

        IBlock ITransaction.Block => Block;


        public DateTime Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);

        double ITransaction.Amount => Amount / 100000000.0;
        double ITransaction.Fee => Fee / 100000000.0;
    }
}
