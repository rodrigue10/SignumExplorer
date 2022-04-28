namespace SignumExplorer.Models
{
    public interface IBlockPoolWon
    {

        public long GeneratorId { get;  }
        public long PoolId { get;  }
        public int Height { get;  }
        public bool Solo { get;  }
    }
}