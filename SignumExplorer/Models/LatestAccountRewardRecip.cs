using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class LatestAccountRewardRecip
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public int CreationHeight { get; set; }
        public byte[]? PublicKey { get; set; }
        public int? KeyHeight { get; set; }
        public long? Balance { get; set; }
        public long? UnconfirmedBalance { get; set; }
        public long? ForgedBalance { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
        public long? RecipId { get; set; }
        public int? FromHeight { get; set; }
        public string? RecipName { get; set; }
        public string? RecipDescrip { get; set; }
    }
}
