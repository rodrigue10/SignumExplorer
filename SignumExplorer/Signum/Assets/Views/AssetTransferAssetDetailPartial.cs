using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AssetTransferAssetDetail : IAssetTransfer
    {
        ulong IAssetTransfer.Id => (ulong)Id;

        ulong IAssetTransfer.AssetId => (ulong)AssetId;

        ulong IAssetTransfer.SenderId => (ulong)SenderId;

        ulong IAssetTransfer.RecipientId => (ulong)RecipientId;

        ulong IAssetTransfer.Quantity => (ulong)Quantity;

        public DateTime Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);

        ulong? IAssetTransfer.AssetQuantity => (ulong)AssetQuantity;

         string? IAssetTransfer.AssetName
        {
            get
            {
                if (AssetName != null)
                {
                    return AssetName;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
