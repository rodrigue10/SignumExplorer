namespace SignumExplorer.Models
{
    public interface IAsset
    {
        public ulong Id { get; }        
        public string Name { get; }
        public string? Description { get; }        
        public ulong Quantity { get; }
        public sbyte Decimals { get; }
        public int Height { get; }
        public ulong AccountId { get; }
        public string AccountRS => ReedSolomon.encode(AccountId);      
        
        
        
        

    }
}
