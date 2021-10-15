using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{


    public partial class AskOrder : IAskOrder
    {


        ulong IAskOrder.Id => (ulong)Id;

        ulong IAskOrder.AccountId => (ulong)AccountId;

        ulong IAskOrder.AssetId => (ulong)AssetId;

        ulong IAskOrder.Price => (ulong)Price;

        ulong IAskOrder.Quantity => (ulong)Quantity;

        //Not able to implement this on DB Table....Use View to access this information
        public sbyte? Decimals => null;

        public ulong? AssetQuantity => null;

        public string? AssetName => null;
    }
}
