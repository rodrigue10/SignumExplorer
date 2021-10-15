using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Escrow
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
        public long Amount { get; set; }
        public int? RequiredSigners { get; set; }
        public int Deadline { get; set; }
        public int DeadlineAction { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
