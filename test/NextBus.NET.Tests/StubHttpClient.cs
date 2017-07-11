using System.Threading.Tasks;

namespace NextBus.NET.Tests
{
    public class StubHttpClient : INextBusHttpClient
    {
        public Task<string> GetAsync(string queryString)
        {
            return Task.FromResult(XmlData);
        }

        private const string XmlData =
            @"<?xml version='1.0' encoding='utf-8' ?>
            <body copyright='All data copyright agencies listed below and NextBus Inc 2017.'>
                <agency tag='ttc' title='Toronto Transit Commission' shortTitle='Toronto TTC' regionTitle='Ontario'/>
                <agency tag='unitrans' title='Unitrans ASUCD/City of Davis' shortTitle='Unitrans' regionTitle='California-Northern'/>
                <agency tag='ucsf' title='University of California San Francisco' regionTitle='California-Northern'/>
            </body>";
    }
}
