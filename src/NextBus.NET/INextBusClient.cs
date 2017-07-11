using System.Threading.Tasks;
using NextBus.NET.Types;

namespace NextBus.NET
{
    public interface INextBusClient
    {
        Task<Agency[]> GetAgenciesAsync();
    }
}
