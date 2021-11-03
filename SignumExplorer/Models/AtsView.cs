using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AtsView
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long CreatorId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public short Version { get; set; }
        public int Csize { get; set; }
        public int Dsize { get; set; }
        public int CUserStackBytes { get; set; }
        public int CCallStackBytes { get; set; }
        public int CreationHeight { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
        public long? ApCodeHashId { get; set; }
        public byte[]? ApCode { get; set; }
    }
}
