using System;
using System.Threading.Tasks;
using NextBus.NET;
using NextBus.NET.Types;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Demo().Wait();
        }

        static async Task Demo()
        {
            INextBusClient client = new NextBusClient();

            Agency[] agencies = await client.GetAgenciesAsync();

            foreach (var agency in agencies)
            {
                Console.WriteLine(agency.Title);
            }
        }
    }
}
