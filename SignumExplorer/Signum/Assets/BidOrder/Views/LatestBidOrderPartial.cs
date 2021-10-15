using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class LatestBidOrder : IBidOrder
    {
        ulong IBidOrder.Id => (ulong)Id;
        ulong IBidOrder.AccountId => (ulong)AccountId;
        ulong IBidOrder.AssetId => (ulong)AssetId;

        ulong IBidOrder.Price => (ulong)Price;

        ulong IBidOrder.Quantity => (ulong)Quantity;

        ulong? IBidOrder.AssetQuantity => (ulong)AssetQuantity;

        string? IBidOrder.AssetName
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
