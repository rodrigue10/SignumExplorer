using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class LatestAskOrder : IAskOrder
    {


        ulong IAskOrder.Id => (ulong)Id;

        ulong IAskOrder.AccountId => (ulong)AccountId;

        ulong IAskOrder.AssetId => (ulong)AssetId;

        ulong IAskOrder.Price => (ulong)Price;

        ulong IAskOrder.Quantity => (ulong)Quantity;

        ulong? IAskOrder.AssetQuantity => (ulong)AssetQuantity;

        string? IAskOrder.AssetName
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
