using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public partial class Asset : IAsset
    {

        ulong IAsset.Id => (ulong)Id;

        ulong IAsset.AccountId => (ulong)AccountId;

        ulong IAsset.Quantity => (ulong)(Quantity/(Math.Pow(10,Decimals)));
    }
}
