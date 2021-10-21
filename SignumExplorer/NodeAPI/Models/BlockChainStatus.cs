using System.Text.Json.Serialization;

namespace SignumExplorer.Models
{

    public class BlockChainStatus
    {
        [JsonPropertyName("application")]
        public string Application { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("lastBlock")]
        public string LastBlock { get; set; }

        [JsonPropertyName("lastBlockTimestamp")]
        public int LastBlockTimestamp { get; set; }

        [JsonPropertyName("cumulativeDifficulty")]
        public string CumulativeDifficulty { get; set; }

        [JsonPropertyName("averageCommitmentNQT")]
        public long AverageCommitmentNQT { get; set; }

        [JsonPropertyName("numberOfBlocks")]
        public int NumberOfBlocks { get; set; }

        [JsonPropertyName("lastBlockchainFeeder")]
        public string LastBlockchainFeeder { get; set; }

        [JsonPropertyName("lastBlockchainFeederHeight")]
        public int LastBlockchainFeederHeight { get; set; }

        [JsonPropertyName("isScanning")]
        public bool IsScanning { get; set; }

        [JsonPropertyName("requestProcessingTime")]
        public int RequestProcessingTime { get; set; }
    }
}
