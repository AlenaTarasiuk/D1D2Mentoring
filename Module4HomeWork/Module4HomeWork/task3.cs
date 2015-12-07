using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HomeWork
{
    class task3
    { }

    public class MyCollection2
    {
       public List<Int32> mylist;

        public MyCollection2()
        {
            mylist = new List<Int32>();
        }

        public void Add(int element)
        {
            mylist.Add(element);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (int number in mylist)
            {
                if (number > 0)
                {
                    yield return number;
                }
                else break;
            }
        }
    }
}