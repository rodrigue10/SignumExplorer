namespace SignumExplorer.Models
{
    public interface IGetPeer
    {

        public int state { get; set; }
        public string announcedAddress { get; set; }
        public bool shareAddress { get; set; }
        public int downloadedVolume { get; set; }
        public int uploadedVolume { get; set; }
        public object application { get; set; }
        public string version { get; set; }
        public object platform { get; set; }
        public bool blacklisted { get; set; }
        public int lastUpdated { get; set; }
        public int requestProcessingTime { get; set; }
    }
}
