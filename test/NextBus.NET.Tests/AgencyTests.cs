using System;
using System.Threading.Tasks;
using Moq;
using NextBus.NET.Types;
using Xunit;

namespace NextBus.NET.Tests
{
    public class AgencyTests
    {
        [Fact(DisplayName = "Should get multiple available agencies")]
        public async Task ShouldGetMultipleAgencies()
        {
            const string xmlData =
                @"<?xml version='1.0' encoding='utf-8' ?>
                <body copyright='All data copyright agencies listed below and NextBus Inc 2017.'>
                    <agency tag='ttc' title='Toronto Transit Commission' shortTitle='Toronto TTC' regionTitle='Ontario'/>
                    <agency tag='unitrans' title='Unitrans ASUCD/City of Davis' shortTitle='Unitrans' regionTitle='California-Northern'/>
                    <agency tag='ucsf' title='University of California San Francisco' regionTitle='California-Northern'/>
                </body>";

            var mockHttpClient = new Mock<INextBusHttpClient>();
            mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(xmlData);

            INextBusClient sut = new NextBusClient(mockHttpClient.Object);
            Agency[] agencies = await sut.GetAgenciesAsync();

            Assert.Equal(3, agencies.Length);
            Assert.All(agencies, a => Assert.NotNull(a.Title));
        }

        [Fact(DisplayName = "Should get empty array of agencies")]
        public async Task ShouldGetNoAgency()
        {
            const string xmlData =
                @"<?xml version='1.0' encoding='utf-8' ?>
                <body copyright='All data copyright agencies listed below and NextBus Inc 2017.'>
                </body>";

            var mockHttpClient = new Mock<INextBusHttpClient>();
            mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(xmlData);

            INextBusClient sut = new NextBusClient(mockHttpClient.Object);
            Agency[] agencies = await sut.GetAgenciesAsync();

            Assert.Empty(agencies);
        }

        [Fact(DisplayName = "Should throw exception on null xml")]
        public async Task ShouldThrowException()
        {
            var mockHttpClient = new Mock<INextBusHttpClient>();
            mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(null as string);

            INextBusClient sut = new NextBusClient(mockHttpClient.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAgenciesAsync());
        }
    }
}
