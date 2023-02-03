using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SignumExplorer.Models
{
    public interface IGetPeers
    {


        public List<string> peers { get; set; }

        public int requestProcessingTime { get; set; }




    }
}
