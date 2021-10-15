using System.ComponentModel;

namespace SignumExplorer.Models
{
    public interface IAccount
    {
        public string IdRS => ReedSolomon.encode(AccountId);
        public ulong AccountId { get; }
        public string? Name { get;}
        public string? Description { get; }
        public double Balance { get;  }
        public double UnconfirmedBalance { get;  }
        public double ForgedBalance { get; }
        public int CreationHeight { get; }        
        public int? KeyHeight { get;  }
        public int Height { get; }
        public string PublicKeyString { get; }
        public bool? Latest { get;  }


    }
}
