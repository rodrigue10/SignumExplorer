using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class LatestAccountBalance : ILatestAccountBalance
    {


        ulong ILatestAccountBalance.AccountId { get => (ulong)Id; }

        public string PublicKeyString
        {
            get
            {

                if (PublicKey != null)
                {
                    return BitConverter.ToString(PublicKey).Replace("-", "");
                }
                else return string.Empty;
            }
        }

        long ILatestAccountBalance.Balance
        {           

            get
            {
                if (Balance != null)
                {
                    return (long)(Balance / 100000000.0);
                }
                else return 0;
            }
        }

        long ILatestAccountBalance.UnconfirmedBalance
        {
            get
            {
                if (Balance != null)
                {
                    return (long)(UnconfirmedBalance / 100000000.0);
                }
                else return 0;

            }
        }

        long ILatestAccountBalance.ForgedBalance
        {
            get
            {
                if (Balance != null)
                {
                    return (long)(ForgedBalance / 100000000.0);
                }
                else
                    return 0;

            }
        }
    }
}
