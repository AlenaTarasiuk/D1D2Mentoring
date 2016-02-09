using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersFibonacci
{
    public interface ICacheNumbers
    {
        int? Get(int keyNum);
        void Set(int keyNum, int value);
    }
}
