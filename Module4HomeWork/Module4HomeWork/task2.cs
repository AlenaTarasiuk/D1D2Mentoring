using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HomeWork
{
    class task2
    { }

    public class MyCollection<T> where T : IComparable<T>
    {
        private List<T> listNumbers;
        private T element;

        public MyCollection()
        {
            listNumbers = new List<T>();
        }

        public void AddElementInCollection(T element)
        {
            listNumbers.Add(element);
        }

        public IEnumerator ComparisonObjectWithElementsCollection(T obj)
        {
            foreach (T element in listNumbers)
            {
                yield return element.CompareTo(obj);
            }
        }

        public IEnumerator ComparisonObjectWithElementsCollection(Object obj)
        {
            foreach (T element in listNumbers)
            {
                yield return element.Equals(obj);
            }
        }
    }
}