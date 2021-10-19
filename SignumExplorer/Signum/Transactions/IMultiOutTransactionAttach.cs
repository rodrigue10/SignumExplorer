namespace SignumExplorer.Models
{
    public interface IMultiOutTransactionAttach
    {
        public long DbId { get; }
        public long Id { get;  }
        public long SenderId { get;  }
        public byte[]? AttachmentBytes { get;  }
        public sbyte Type { get; }
        public sbyte Subtype { get;  }
        public long Amount { get;  }
        public long Fee { get;  }
        public int Timestamp { get;  }
        public string? SenderName { get;  }

    }
}
