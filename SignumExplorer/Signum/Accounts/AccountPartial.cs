using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public partial class Account : IAccount
    {

        public string PublicKeyString
        {
            get {

                if (PublicKey != null)
                {
                    return BitConverter.ToString(PublicKey).Replace("-", "");
                }
                else return string.Empty;
            }
        }

        ulong IAccount.AccountId { get => (ulong)Id;  }


    }
}
