using Microsoft.Extensions.Configuration;
using SignumExplorer.CoinGeckoAPI.Models;
using SignumExplorer.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SignumExplorer.CoinGeckoAPI.Services
{
    public interface ICoinGeckoAPIService
    {

        public Task<SimplePrice?> GetSimplePrice();

    }

    public class CoinGeckoAPIService : ICoinGeckoAPIService
    {
        public HttpClient Client { get;  }
        IConfiguration? _configuraton;
      
        //private readonly JsonSerializerOptions _options;

         // "CoinGeckoUri": "https://api.coingecko.com/api/v3/simple/price?ids=signum&vs_currencies=btc%2Cusd&include_market_cap=true&include_24hr_vol=true&include_24hr_change=true&include_last_updated_at=true",


        public CoinGeckoAPIService(HttpClient client, IConfiguration configuration)
        {
            _configuraton = configuration;
            client.BaseAddress = new Uri(_configuraton["CoinGeckoProcessor:Uri"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
           
            //_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};

            Client = client;

        }

        public async Task<SimplePrice?> GetSimplePrice()
        {
                   

            string baseAPI = "/api/v3/simple/price";
            string requestType = "?ids=signum&vs_currencies=btc%2Cusd&include_market_cap=true&include_24hr_vol=true&include_24hr_change=true&include_last_updated_at=true";

            StringBuilder uri = new();

            uri.Append(baseAPI);
            uri.Append(requestType);


            try
            {
                return await Client.GetFromJsonAsync<SimplePrice>(uri.ToString());
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
