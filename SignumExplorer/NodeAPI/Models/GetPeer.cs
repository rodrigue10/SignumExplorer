using System.Text.Json.Serialization;

namespace SignumExplorer.Models
{
    public class GetPeer : IGetPeer
    {

        [JsonPropertyName("state")]
        public int state { get; set; }

        [JsonPropertyName("announcedAddress")]
        public string announcedAddress { get; set; }

        [JsonPropertyName("shareAddress")]
        public bool shareAddress { get; set; }

        [JsonPropertyName("downloadedVolume")]
        public int downloadedVolume { get; set; }

        [JsonPropertyName("uploadedVolume")]
        public int uploadedVolume { get; set; }

        [JsonPropertyName("application")]
        public object application { get; set; }

        [JsonPropertyName("version")]
        public string version { get; set; }

        [JsonPropertyName("platform")]
        public object platform { get; set; }

        [JsonPropertyName("blacklisted")]
        public bool blacklisted { get; set; }

        [JsonPropertyName("lastUpdated")]
        public int lastUpdated { get; set; }

        [JsonPropertyName("requestProcessingTime")]
        public int requestProcessingTime { get; set; }
    }
}
