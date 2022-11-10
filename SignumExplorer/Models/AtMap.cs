using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AtMap
    {
        public long DbId { get; set; }
        public long AtId { get; set; }
        public long Key1 { get; set; }
        public long? Key2 { get; set; }
        public long? Value { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
