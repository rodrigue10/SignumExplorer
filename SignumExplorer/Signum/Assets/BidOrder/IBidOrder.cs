namespace SignumExplorer.Models
{
    public interface IBidOrder
    {
        public ulong Id { get; }
        public ulong AccountId { get; }
        public ulong AssetId { get; }
        public ulong Price { get; }
        public ulong Quantity { get; }
        public int CreationHeight { get; }
        public int Height { get; }
        public bool? Latest { get; }

        public string AccountRS => ReedSolomon.encode(AccountId);


        public sbyte? Decimals { get; }
        public ulong? AssetQuantity { get; }

        public string? AssetName { get; }
    }
}
