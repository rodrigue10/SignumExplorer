using System;

namespace SignumExplorer.Models
{
    public interface IAlias
    {

            public ulong Id { get;  }
            public ulong AccountId { get; }
            public string AliasName { get;  } 
            public string AliasNameLower { get;  } 
            public string AliasUri { get;  } 
            public int Timestamp { get;  }
            public int Height { get;  }
            public bool? Latest { get;  }

            public string AccountRS => ReedSolomon.encode(AccountId);

            public DateTime Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);

    }
}
