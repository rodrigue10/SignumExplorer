using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SignumExplorer.Models
{
    public class GetPeers :IGetPeers
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

            [JsonPropertyName("peers")]
            public List<string> peers { get; set; }

            [JsonPropertyName("requestProcessingTime")]
            public int requestProcessingTime { get; set; }
        
    }
}
