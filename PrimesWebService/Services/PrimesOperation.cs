using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrimesWebService.Services
{
    public class PrimesOperation : IPrimesOperation
    {
        public async Task<bool> IsPrime(int x)
        {
            if (x < 2)
                return await Task.FromResult(false);
            for (int i = 2; i <= x / i; i++)
                if (x % i == 0)
                    return await Task.FromResult(false);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<int>> GetPrimes(int from, int to)
        {
            return await Task.FromResult(Enumerable.Range(from, to - from + 1)
                                             .Where(x => x > 1 && Enumerable.Range(2, x - 2)
                                                                            .All(y => x % y != 0)));
        }
    }
}
