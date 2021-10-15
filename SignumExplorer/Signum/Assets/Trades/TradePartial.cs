using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public partial class Trade : ITrade
    {


        ulong ITrade.AssetId => (ulong)AssetId;

        ulong ITrade.BlockId => (ulong)BlockId;

        ulong ITrade.AskOrderId => (ulong)AskOrderId;

        ulong ITrade.BidOrderId => (ulong)BidOrderId;

        ulong ITrade.SellerId => (ulong)SellerId;

        ulong ITrade.BuyerId => (ulong)BuyerId;

        ulong ITrade.Quantity => (ulong)Quantity;

        ulong ITrade.Price => (ulong)Price;

        DateTime ITrade.Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);


        //Not able to implement this on DB Table.  Use appropriate VIEW model.
        public ulong? AssetQuantity => null;

        public sbyte? Decimals => null;

        public string? AssetName => null;
   



    }
}
