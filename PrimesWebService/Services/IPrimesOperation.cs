using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PrimesWebService.Services
{
    public interface IPrimesOperation
    {
        public Task<bool> IsPrime(int x);

        public Task<IEnumerable<int>> GetPrimes(int from, int to);
    }
}
