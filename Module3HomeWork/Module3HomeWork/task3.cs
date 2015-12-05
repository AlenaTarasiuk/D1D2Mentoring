using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HomeWork
{
    class task3
    {
        public void Helper()
        {
            string[] strmass = { "ds", "saf", "saf" };

            var strResult = new StringBuilder();
            for (int i = 0; i < strmass.Length; i++)
            {
                if (i % 2 == 1)
                    strResult.Append(strmass[i]);
            }

            string str = strResult.ToString();
        }
    }
}
