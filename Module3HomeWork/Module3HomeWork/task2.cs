using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HomeWork
{
    class task2
    {
        public int CompareWords(string x, string y)
        {
            if (x == null)
            {
                return (y == null) ? 0 : -1;
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int retval = String.Compare(x, y, StringComparison.OrdinalIgnoreCase);

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return String.Compare(y, x, StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
        }
    }
}
