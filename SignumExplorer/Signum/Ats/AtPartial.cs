using SignumExplorer.Signum;
using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{


    public partial class At : IAt
    {


        ulong IAt.Id => (ulong)Id;

        ulong IAt.CreatorId => (ulong)CreatorId;

        ulong? IAt.ApCodeHashId
        {
            get
            {
                if (ApCodeHashId != null)
                {
                    return (ulong)ApCodeHashId;
                }
                else
                {
                    return 0;
                }
            }
        }

        string IAt.ApCodeString
        {
            get
            {

                if (ApCode != null)
                {

                    return BitConverter.ToString(ApCode.Decompress()).Replace("-", "");

                }
                else { return string.Empty; }
            }
        }

    }
}
