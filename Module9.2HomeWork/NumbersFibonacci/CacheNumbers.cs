using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace NumbersFibonacci
{
    public class CacheNumbers : ICacheNumbers
    {
        private static ObjectCache cache = MemoryCache.Default;

        public int? Get(int keyNum)
        {
            return (int?)cache.Get(keyNum.ToString());
        }

        public void Set(int keyNum, int value)
        {
            cache.Set(keyNum.ToString(), value, ObjectCache.InfiniteAbsoluteExpiration);
        }
    }
}
