using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class BlockPoolWon
    {
        public int Height { get; set; }
        public long GeneratorId { get; set; }
        public long PoolId { get; set; }
        public int Solo { get; set; }
    }
}
