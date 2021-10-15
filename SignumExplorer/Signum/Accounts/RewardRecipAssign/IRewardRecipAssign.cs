namespace SignumExplorer.Models
{
    public interface IRewardRecipAssign
    {

 
        public ulong AccountId { get;  }
        public ulong PrevRecipId { get;  }
        public ulong RecipId { get;  }
        public int FromHeight { get;  }
        public int Height { get;  }
        public bool Latest { get;  }

        public string AccountRS => ReedSolomon.encode(AccountId);
        public string PrevRecipRS => ReedSolomon.encode(PrevRecipId);
        public string RecipRS => ReedSolomon.encode(RecipId);

        public string? RecipName { get;  }
        public string? RecipDescrip { get;  }

    }
}
