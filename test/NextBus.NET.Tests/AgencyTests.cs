using System;
using System.Threading.Tasks;
using NextBus.NET.Types;
using Xunit;

namespace NextBus.NET.Tests
{
    public class AgencyTests
    {
        [Fact(DisplayName = "Should get multiple available agencies")]
        public async Task ShouldGetMultipleAgencies()
        {
            INextBusHttpClient stub1 = new StubHttpClient();
            INextBusClient sut = new NextBusClient(stub1);

            Agency[] agencies = await sut.GetAgenciesAsync();

            Assert.Equal(3, agencies.Length);
            Assert.All(agencies, a => Assert.NotNull(a.Title));
        }

        [Fact(DisplayName = "Should get empty array of agencies")]
        public async Task ShouldGetNoAgency()
        {
            INextBusHttpClient stub2 = new StubHttpClient2();
            INextBusClient sut = new NextBusClient(stub2);

            Agency[] agencies = await sut.GetAgenciesAsync();

            Assert.Empty(agencies);
        }

        [Fact(DisplayName = "Should throw exception on null xml")]
        public async Task ShouldThrowException()
        {
            INextBusHttpClient stub3 = new StubHttpClient3();

            INextBusClient sut = new NextBusClient(stub3);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAgenciesAsync());
        }
    }
}
