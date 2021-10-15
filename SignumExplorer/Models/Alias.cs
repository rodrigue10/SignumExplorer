using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Alias
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string AliasName { get; set; } = null!;
        public string AliasNameLower { get; set; } = null!;
        public string AliasUri { get; set; } = null!;
        public int Timestamp { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
