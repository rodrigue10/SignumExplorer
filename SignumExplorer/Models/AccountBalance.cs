using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AccountBalance
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long Balance { get; set; }
        public long UnconfirmedBalance { get; set; }
        public long ForgedBalance { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
