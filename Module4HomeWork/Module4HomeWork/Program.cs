using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace Module4HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
//1
            task1 objTask1 = new task1();
            Stopwatch stopWatch = new Stopwatch();

            Start(stopWatch);
            objTask1.AddToDictionary();
            Finish(stopWatch);          
            Start(stopWatch);
            Console.WriteLine(objTask1.SearchStringInDictinory("500"));
            Finish(stopWatch);

            Start(stopWatch);
            objTask1.AddToList();
            Finish(stopWatch);           
            Start(stopWatch);
            Console.WriteLine(objTask1.SearchStringInList("Two households, both alike in dignity,"));
            Finish(stopWatch);

//2
            MyCollection<int> myCollection = new MyCollection<int>();
            myCollection.AddElementInCollection(23);
            myCollection.AddElementInCollection(7);
            myCollection.AddElementInCollection(3);
            IEnumerator result1 = myCollection.ComparisonObjectWithElementsCollection(23);
            IEnumerator result2 = myCollection.ComparisonObjectWithElementsCollection("23");

//3            
            MyCollection2 myCollect = new MyCollection2();
            myCollect.Add(2);
            myCollect.Add(5);
            myCollect.Add(-10);
            myCollect.Add(1);

            foreach (int i in myCollect)
            {
                System.Console.Write(i + " ");
            }
        }

        private static void Finish(Stopwatch stopWatch)
        {
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
        }

        private static void Start(Stopwatch stopWatch)
        {
            stopWatch.Start();
        }
        
    }
}
