using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

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
            task2 objTask2 = new task2();


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
