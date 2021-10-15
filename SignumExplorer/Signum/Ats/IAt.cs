using SignumExplorer.Signum;
using System;

namespace SignumExplorer.Models
{
    public interface IAt
    {
        public string? AtIdRS => ReedSolomon.encode(Id);
        public ulong Id { get;  }
        public string? Name { get; }
        public string? Description { get; }
        public string? CreatorRS => ReedSolomon.encode(CreatorId);
        public ulong CreatorId { get;  }
        public int Csize { get;  }
        public int Dsize { get;  }
        public int CUserStackBytes { get;  }
        public int CCallStackBytes { get;  }
        public int CreationHeight { get;  }
        public int Height { get;  }
        public short Version { get; }
        public bool? Latest { get;  }
        public ulong? ApCodeHashId { get;  }
        public string ApCodeString { get; }


    }
}
