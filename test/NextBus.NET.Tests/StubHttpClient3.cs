using System.Threading.Tasks;

namespace NextBus.NET.Tests
{
    public class StubHttpClient3 : INextBusHttpClient
    {
        public Task<string> GetAsync(string queryString)
        {
            return Task.FromResult<string>(null);
        }
    }
}
