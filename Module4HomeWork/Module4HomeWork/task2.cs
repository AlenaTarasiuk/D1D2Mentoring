using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HomeWork
{
    class task2 : IComparable<int>
    {
        List<int> listNumbers = new List<int>();

        public void ComparisonObjectWithElementsCollection(object obj)
        {
            foreach (int element in listNumbers)
            {
                element.CompareTo(obj);
            }
        }

        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }
    }
}
