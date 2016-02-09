using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NumbersFibonacci
{
    public class Fibonacci
    {
        ICacheNumbers cache;
        public Fibonacci(ICacheNumbers cache)
        {
            this.cache = cache;
        }

        public int GetNumber(int num)
        {
            int? result = cache.Get(num);
            if (result != null)
                return (int)result;
            else
            {
                return (num < 3) ? 1 : GetNumber(num - 1) + GetNumber(num - 2);       
            }
        }
    }
}
