namespace SignumExplorer.Models
{
    public partial class AliasOffer : IAliasOffer
    {
        ulong IAliasOffer.Id => (ulong)Id;

        ulong IAliasOffer.BuyerId
        {
            get 
            {
                
                if(BuyerId != null)
                
                {
                        return (ulong)BuyerId;
                }
                else return 0;
                
                
                
                
            }
        }
    
    }


}
