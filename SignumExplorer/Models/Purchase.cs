using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Purchase
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long BuyerId { get; set; }
        public long GoodsId { get; set; }
        public long SellerId { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public int Deadline { get; set; }
        public byte[]? Note { get; set; }
        public byte[]? Nonce { get; set; }
        public int Timestamp { get; set; }
        public bool Pending { get; set; }
        public byte[]? Goods { get; set; }
        public byte[]? GoodsNonce { get; set; }
        public byte[]? RefundNote { get; set; }
        public byte[]? RefundNonce { get; set; }
        public bool HasFeedbackNotes { get; set; }
        public bool HasPublicFeedbacks { get; set; }
        public long Discount { get; set; }
        public long Refund { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
