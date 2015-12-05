using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HomeWork
{
    class task3
    {
        class MyCollection : IEnumerable<int>
        {
            private Random rand = new Random();

            public IEnumerator<int> GetEnumerator()
            {
                while (true)
                    yield return rand.Next();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
