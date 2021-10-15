using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class RewardRecipNameDesc : IRewardRecipAssign
    {
            


        //RewardRecipAssign Table Typicals

        ulong IRewardRecipAssign.AccountId => (ulong)AccountId;

        ulong IRewardRecipAssign.PrevRecipId => (ulong)PrevRecipId;

        ulong IRewardRecipAssign.RecipId => (ulong)RecipId;

        bool IRewardRecipAssign.Latest
        {
            get
            {
                if (Latest == null)
                {
                    return false;
                }
                else
                {
                    return (bool)Latest;
                }

            }
        }
    }
}
