using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{


    public partial class AssetTransfer : IAssetTransfer
    {

        ulong IAssetTransfer.Id => (ulong)Id;

        ulong IAssetTransfer.AssetId => (ulong)AssetId;

        ulong IAssetTransfer.SenderId => (ulong)SenderId;

        ulong IAssetTransfer.RecipientId => (ulong)RecipientId;

        ulong IAssetTransfer.Quantity => (ulong)Quantity;

        public DateTime Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);



        //Not able to iimplement this on the DB Table.  Look to use the View if this is needed.
        public ulong? AssetQuantity => null;

        public sbyte? Decimals => null;

        public string? AssetName => null;
        
    }
}
