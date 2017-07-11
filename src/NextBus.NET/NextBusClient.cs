using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using NextBus.NET.Types;

namespace NextBus.NET
{
    public class NextBusClient : INextBusClient
    {
        private readonly INextBusHttpClient _httpClient;

        public NextBusClient()
            : this(new NextBusHttpClient())
        {

        }

        public NextBusClient(INextBusHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Agency[]> GetAgenciesAsync()
        {
            string xml = await _httpClient.GetAsync("command=agencyList");

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
