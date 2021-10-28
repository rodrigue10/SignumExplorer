using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SignumExplorer.Models
{


    public interface IGetUnconfirmedTransaction
    {
        
        public int Type { get; }
        public int Subtype { get;  }  
        
        public string TransactionType => TransactionTypes.TransactionDescription(Type,Subtype);

        public int Timestamp { get;  }

        public DateTime Time => new DateTime(2014, 8, 11, 2, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);

        public int Deadline { get;  }
        public string SenderPublicKey { get;  }

        public string AmountNQT { get;  }
        public double AmountSigna => ulong.Parse(AmountNQT) / 100000000.0;
        
        public string FeeNQT { get;  }
        public double FeeSigna => ulong.Parse(FeeNQT) / 100000000.0;

        public string Signature { get;  }  
        public string SignatureHash { get; }
        public string FullHash { get;  }    
        public string Transaction { get;  }
        public string Sender { get;  }
        public ulong SenderId => ulong.Parse(Sender);
        public string SenderRS { get; }
        public int Height { get;  }  
        public int Version { get;  }   
        public string EcBlockId { get;  }
        public int EcBlockHeight { get;  }  
        public string Recipient { get;  }        
        public ulong RecipientId
        {
            get
            {
                  return ulong.TryParse(Recipient, out var recipientId) ? recipientId : ulong.MinValue;
            }
        }
        public string RecipientRS { get;  }


    }
    public interface IUnconfirmedTransAPI
    {

        public List<IGetUnconfirmedTransaction> UnconfirmedTransactions { get;  }
        public int RequestProcessingTime { get;  }

    }




    public class UnconfirmedTransAPI : IUnconfirmedTransAPI
    {

        [JsonPropertyName("unconfirmedTransactions")]
        public List<GetUnconfirmedTransaction> UnconfirmedTransactions {get; set;}

        [JsonPropertyName("requestProcessingTime")]
        public int RequestProcessingTime { get; set; }

        List<IGetUnconfirmedTransaction> IUnconfirmedTransAPI.UnconfirmedTransactions => new List<IGetUnconfirmedTransaction>(UnconfirmedTransactions);
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
   

    public class GetUnconfirmedTransaction : IGetUnconfirmedTransaction
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("subtype")]
        public int Subtype { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("deadline")]
        public int Deadline { get; set; }

        [JsonPropertyName("senderPublicKey")]
        public string SenderPublicKey { get; set; }

        [JsonPropertyName("amountNQT")]
        public string AmountNQT { get; set; }

        [JsonPropertyName("feeNQT")]
        public string FeeNQT { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }

        [JsonPropertyName("signatureHash")]
        public string SignatureHash { get; set; }

        [JsonPropertyName("fullHash")]
        public string FullHash { get; set; }

        [JsonPropertyName("transaction")]
        public string Transaction { get; set; }

        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        [JsonPropertyName("senderRS")]
        public string SenderRS { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("ecBlockId")]
        public string EcBlockId { get; set; }

        [JsonPropertyName("ecBlockHeight")]
        public int EcBlockHeight { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; }

        [JsonPropertyName("recipientRS")]
        public string RecipientRS { get; set; }
    }




}
