namespace SignumExplorer.Models
{
    public interface IAccountAsset
    {
  
         
            public ulong AccountId { get;  }
            public ulong AssetId { get;  }
            public ulong Quantity { get;  }
            public ulong UnconfirmedQuantity { get;  }
            public int Height { get;  }
            public bool? Latest { get; }

            public string AccountRS => ReedSolomon.encode(AccountId);

    }

}
