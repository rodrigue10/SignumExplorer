namespace SignumExplorer.Models
{
    public partial class Alias : IAlias
    {
        ulong IAlias.AccountId => (ulong)AccountId;

        ulong IAlias.Id => (ulong)Id;

    }
}
