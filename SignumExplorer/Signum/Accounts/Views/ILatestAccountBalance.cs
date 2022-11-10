using SignumExplorer.Pages;

namespace SignumExplorer.Models
{
    public interface ILatestAccountBalance
    {
        public ulong AccountId { get; }
        public string IdRS => ReedSolomon.encode((ulong)Id);
        public long DbId { get; }
        public long Id { get; }
        public int CreationHeight { get; }
        public byte[]? PublicKey { get; }
        public int? KeyHeight { get; }
        public long Balance { get; }
        public long UnconfirmedBalance { get; }
        public long ForgedBalance { get;   }
        public string? Name { get; }
        public string? Description { get; }
        public int Height { get; }
        public bool? Latest { get; }


    }
}