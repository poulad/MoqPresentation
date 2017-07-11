using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NextBus.NET
{
    public class NextBusHttpClient : INextBusHttpClient
    {
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri(BaseUrl) };

        private const string BaseUrl = "http://webservices.nextbus.com/service/publicXMLFeed";

        public async Task<string> GetAsync(string queryString)
        {
            var response = await _client.GetAsync("?" + queryString);
            string xml = await response.Content.ReadAsStringAsync();
            
            return xml;
        }
    }
}
