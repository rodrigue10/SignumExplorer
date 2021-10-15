using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public partial class BidOrder : IBidOrder
    {


        ulong IBidOrder.Id => (ulong)Id;
        ulong IBidOrder.AccountId => (ulong)AccountId;
        ulong IBidOrder.AssetId => (ulong)AssetId;

        ulong IBidOrder.Price => (ulong)Price;

        ulong IBidOrder.Quantity => (ulong)Quantity;

        //Not able to implement this on DB Table....Use View to access this information
        public sbyte? Decimals => null;

        public ulong? AssetQuantity => null;

        public string? AssetName => null;
    }
}
