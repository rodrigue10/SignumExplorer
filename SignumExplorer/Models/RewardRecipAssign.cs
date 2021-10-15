using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class RewardRecipAssign
    {
        public long DbId { get; set; }
        public long AccountId { get; set; }
        public long PrevRecipId { get; set; }
        public long RecipId { get; set; }
        public int FromHeight { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
