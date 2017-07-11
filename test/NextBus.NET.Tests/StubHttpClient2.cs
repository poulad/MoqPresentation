using System.Threading.Tasks;

namespace NextBus.NET.Tests
{
    public class StubHttpClient2 : INextBusHttpClient
    {
        public Task<string> GetAsync(string queryString)
        {
            return Task.FromResult(XmlData);
        }

        private const string XmlData =
            @"<?xml version='1.0' encoding='utf-8' ?>
            <body copyright='All data copyright agencies listed below and NextBus Inc 2017.'>
            </body>";
    }
}
