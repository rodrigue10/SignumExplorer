namespace SignumExplorer.Models
{
    public partial class AccountAsset : IAccountAsset
    {
        ulong IAccountAsset.AccountId => (ulong)AccountId;

        ulong IAccountAsset.AssetId => (ulong)AssetId;

        ulong IAccountAsset.Quantity => (ulong)Quantity;

        ulong IAccountAsset.UnconfirmedQuantity => (ulong)UnconfirmedQuantity;
    }

}
