using System;
using System.Threading.Tasks;
using PrimesTestApp.Tests;

namespace PrimesTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var testing = new Testing();
            try
            {
                await testing.TestIsPrimesEndpoint("/", 200);

                await testing.TestIsPrimesEndpoint("/primes/2", 200);

                await testing.TestIsPrimesEndpoint("/primes/4", 404);

                await testing.TestIsPrimesEndpoint("/primes?from=0&to=5", 200);

                await testing.TestIsPrimesEndpoint("/primes?from=-5&to=1", 200);

                await testing.TestIsPrimesEndpoint("/primes?to=abcd", 400);
            }
            catch (Exception)
            {
                Console.WriteLine(" Oops! Something went wrong.");
            }
        }
    }
}
