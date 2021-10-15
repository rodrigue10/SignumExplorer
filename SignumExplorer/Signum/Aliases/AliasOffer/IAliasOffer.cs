namespace SignumExplorer.Models
{
    public interface IAliasOffer
    {
        public long DbId { get;  }
        public ulong Id { get;  }
        public long Price { get;  }
        public ulong BuyerId { get; }
        public string? BuyerRS => ReedSolomon.encode(BuyerId);
        public int Height { get;  }
        public bool? Latest { get;  }

    }


}
