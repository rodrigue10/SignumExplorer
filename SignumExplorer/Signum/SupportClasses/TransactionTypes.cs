using System;

namespace SignumExplorer.Models
{
    public static class TransactionTypes
    {
        public static string? TransactionDescription(int PrimaryType, int SubType)
        {
             var primaryType = Enum.GetName(typeof(Primary), PrimaryType);

            var fullname = typeof(Primary).FullName;

                if (fullname != null)
                {
                    fullname.Replace("Primary", primaryType);

                    Type? enumtype = Type.GetType(fullname);
                    if (enumtype != null)
                    {
                        return Enum.GetName(enumtype, SubType);
                    }
                    else { return ""; }

                }
                else
                {
                    return "";

                }


        }
         public enum Primary
        {
            Payment = 0,
            Messaging = 1,
            ColoredCoins = 2,
            DigitalGoods = 3,
            AccountControl = 4,
            SignaMining = 20,
            AdvancedPayment = 21,
            AutomatedTransactions = 22
            
        
        }

         public enum Payment
        {
            OrdinaryPayment = 0,
            MultiOutPayment = 1,
            MultiOutSamePayment = 2
        }


         public enum Messaging
        {

            ArbitraryMessage = 0,
            AliasAssignment = 1,
            AccountInfo = 5,
            AliasSell = 6,
            AliasBuy = 7


        }


        public enum ColoredCoins
        {

            AssetIssuance = 0,
            AssetTransfer = 1,
            AskOrderPlacement = 2,
            BidOrderPlacement = 3,
            AskOrderCancellation = 4,
            BidOrderCancellation = 5,



        }


        public enum DigitalGoods
        {

            Listing = 0,
            DeListing = 1,
            PriceChange = 2,
            QuantityChange = 3,
            Purchase = 4,
            Delivery = 5,
            Feedback = 6,
            Refund = 7

        }




        public enum AccountControl
        {
            EffectiveBalanceLeasing = 0

        }



        public enum SignaMining
        {
            RewardRecipientAssignment = 0,
            AddCommitment = 1,
            RemoveCommitment = 2,

        }


        public enum AdvancedPayment
        {

            EscrowCreation = 0,
            EscrowSign = 1,
            EscrowResult = 2,
            SubscriptionSubscribe = 3,
            SubscriptionCancel = 4,
            SubscriptionPayment = 5,

        }

 

        public enum AutomatedTransactions
        {

            AT_Creation = 0,
            AT_Payment = 1

        }


    public enum PeerStates
    {
        NonConnected = 0,
        Connected = 1,
        Disconnected = 2
    }

    }


 
    
}
