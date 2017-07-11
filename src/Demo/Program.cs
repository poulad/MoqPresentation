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
            var client = new NextBusClient();

            Agency[] agencies = await client.GetAgencies();

            foreach (var agency in agencies)
            {
                Console.WriteLine(agency.Title);
            }
        }
    }
}
