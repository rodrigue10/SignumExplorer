using System;

namespace SignumExplorer.Models
{
    public interface IBlockChainStatus
    {

        public string Application { get;  }

        public string Version { get;  }

        public int Time { get;  }

        public DateTime DateAndTime => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Time);
       

        public string LastBlock { get;  }

        public int LastBlockTimestamp { get;  }

 
        public string CumulativeDifficulty { get; }

        public long AverageCommitmentNQT { get;  }
         
        public double AverageCommitmentSigna => AverageCommitmentNQT / 100000000.0;

        public int NumberOfBlocks { get;  }
   
        public string LastBlockchainFeeder { get;  }
        public int LastBlockchainFeederHeight { get;  }

        public bool IsScanning { get;  }
        public int RequestProcessingTime { get;  }
    }
}
