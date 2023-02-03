using Microsoft.Extensions.Configuration;
using SignumExplorer.Models;
using SignumExplorer.Pages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SignumExplorer.Data
{
    public interface ISignumAPIService
    {

        public Task<UnconfirmedTransAPI?> getUnconfirmedTransactions(string accountID = "", string includeIndirect = "true");
        public Task<BlockChainStatus?> getBlockChainStats();

        public Task<GetPeers?> getPeers();
        public Task<GetPeer?> getPeer(string peerID = "");

      

    }

    public class SignumAPIService : ISignumAPIService
    {
        public HttpClient Client { get;  }
      
        //private readonly JsonSerializerOptions _options;

        public SignumAPIService(HttpClient client)
        {

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            //_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};

            Client = client;

        }

        public async Task<UnconfirmedTransAPI?> getUnconfirmedTransactions(string accountID = "", string includeIndirect = "true")
        {
            



            string baseAPI = "/burst";
            string requestType = "?requestType=getUnconfirmedTransactions";


            List<KeyValuePair<string, string>> allIputParams = new()
            {
                // Converting Request Params to Key Value Pair.  
                new KeyValuePair<string, string>("&account=", accountID),
                new KeyValuePair<string, string>("&includeIndirect=", includeIndirect),

            };

            StringBuilder uri = new();

            uri.Append(baseAPI);
            uri.Append(requestType);

            foreach (var item in allIputParams)
            {
                uri.Append(item.Key);
                uri.Append(item.Value);

            }


            try
            {
                return await Client.GetFromJsonAsync<UnconfirmedTransAPI>(uri.ToString());
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;

        }

        public async Task<BlockChainStatus?> getBlockChainStats()
        {
                   

            string baseAPI = "/burst";
            string requestType = "?requestType=getBlockchainStatus";


            List<KeyValuePair<string, string>> allIputParams = new()
            {
                // Converting Request Params to Key Value Pair.  
               // new KeyValuePair<string, string>("&account=", accountID),
                //new KeyValuePair<string, string>("&includeIndirect=", includeIndirect),

            };

            StringBuilder uri = new();

            uri.Append(baseAPI);
            uri.Append(requestType);

            foreach (var item in allIputParams)
            {
                uri.Append(item.Key);
                uri.Append(item.Value);

            }


            try
            {
                return await Client.GetFromJsonAsync<BlockChainStatus>(uri.ToString());
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;

        }

        public async Task<GetPeers?> getPeers()
        {


            string baseAPI = "/burst";
            string requestType = "?requestType=getPeers";


            List<KeyValuePair<string, string>> allIputParams = new()
            {
                // Converting Request Params to Key Value Pair.  
                // new KeyValuePair<string, string>("&account=", accountID),
                //new KeyValuePair<string, string>("&includeIndirect=", includeIndirect),

            };

            StringBuilder uri = new();

            uri.Append(baseAPI);
            uri.Append(requestType);

            foreach (var item in allIputParams)
            {
                uri.Append(item.Key);
                uri.Append(item.Value);

            }


            try
            {
                return await Client.GetFromJsonAsync<GetPeers>(uri.ToString());
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;
        }

        public async Task<GetPeer?> getPeer(string peerIP = "")
        {

            //http://csrs-node:7225/api?requestType=getPeer&peer=23.16.167.189"




            string baseAPI = "/burst";
            string requestType = "?requestType=getPeer";


            List<KeyValuePair<string, string>> allIputParams = new()
            {
                // Converting Request Params to Key Value Pair.  
                new KeyValuePair<string, string>("&peer=", peerIP)

            };

            StringBuilder uri = new();

            uri.Append(baseAPI);
            uri.Append(requestType);

            foreach (var item in allIputParams)
            {
                uri.Append(item.Key);
                uri.Append(item.Value);

            }


            try
            {
                return await Client.GetFromJsonAsync<GetPeer>(uri.ToString());
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;
        }
    }
}
