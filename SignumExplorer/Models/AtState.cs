using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{

    public partial class AtState
    {
        public long DbId { get; set; }
        public long AtId { get; set; }
        public byte[] State { get; set; } = null!;
        public int PrevHeight { get; set; }
        public int NextHeight { get; set; }
        public int SleepBetween { get; set; }
        public long PrevBalance { get; set; }
        public bool FreezeWhenSameBalance { get; set; }
        public long MinActivateAmount { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }


}
