using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SignumExplorer.Models
{
    public class UnconfirmedTransAPI
    {

        [JsonPropertyName("unconfirmedTransactions")]
        public List<GetUnconfirmedTransaction> UnconfirmedTransactions {get; set;}

        [JsonPropertyName("requestProcessingTime")]
        public int RequestProcessingTime { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
   

    public class GetUnconfirmedTransaction
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
