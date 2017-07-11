using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using NextBus.NET.Types;

namespace NextBus.NET
{
    public class NextBusClient
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };

        private const string BaseUrl = "http://webservices.nextbus.com/service/publicXMLFeed";

        public async Task<Agency[]> GetAgencies()
        {
            var response = await _httpClient.GetAsync("?command=agencyList");
            string xml = await response.Content.ReadAsStringAsync();

            var document = XDocument.Parse(xml);

            var query = from x in document.Root?.Elements("agency")
                        select new Agency
                        {
                            Tag = x.Attribute("tag")?.Value,
                            Title = x.Attribute("title")?.Value,
                            ShortTitle = x.Attribute("shortTitle")?.Value,
                            RegionTitle = x.Attribute("regionTitle")?.Value,
                        };

            Agency[] agencies = query.ToArray();

            return agencies;
        }
    }
}
