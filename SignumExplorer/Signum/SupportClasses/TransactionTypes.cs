using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public static class TransactionTypes
    {   

        public static string TransactionDescription(int PrimaryType, int SubType)
        {            

            if (TransactionSubTypes.TryGetValue((PrimaryType, SubType), out string? result))
            {
                return result;
            }
            else
            {
                return string.Empty;
            }

        }

        private static readonly Dictionary<(int, int), string> TransactionSubTypes = new Dictionary<(int, int), string>()
        {

            //Payment (0) SubTypes
           {(0,0), "OrdinaryPayment" },
           {(0,1),"MultiOutPayment" },
            {(0,2),"MultiOutSame" },

            //Messaging (1) SubTypes
            {(1,0), "ArbitraryMessage" },
            {(1,1),"AliasAssignent" },
            {(1,5),"AccountInfo" },
            {(1,6),"AliasSell" },
            {(1,7),"AliasBuy" },

            //ColoredCoins (2) SubTypes
            {(2,0), "AssetIssuance" },
            {(2,1), "AssetTransfer" },
            {(2,2), "AskOrderPlacement" },
            {(2,3), "BidOrderPlacement" },
            {(2,4),  "AskOrderCancellation" },
            {(2,5), "BidOrderCancellation" },

            //Digital Goods (3) SubTypes
            {(3,0), "Listing" },
            {(3,1),"DeListing" },
            {(3,2),"PriceChange" },
            {(3,4), "QuantityChange" },
            {(3,5), "Purchase" },
            {(3,6), "Delivery"},
            {(3,7), "Refund" },

            //AccountControl (4) SubTypes
            {(4,0), "EffectiveBalanceLeasing" },

            //SignaMining (20) SubTypes
            {(20,0), "RewardRecipientAssignment"},
            {(20,1), "AddCommitment" },
            {(20,2), "RemoveCommitment" },

            //AdvancedPayment (21) SubTypes
            {(21,0), "EscrowCreation" },
            {(21,1),"EscrowSign" },
            {(21,2),"SubscriptionSubscribe" },
            {(21,3),"SubscriptionCancel" },
            {(21,4),"SubscriptionPayment" },

            {(22,0), "AT_Creation" },
            {(22,1), "AT_Payment" }

        };


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
