using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Module7HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1
            IList list = task1.CreateAndFillList();
            foreach (int s in list)
                Console.WriteLine(s);

            //task2
            task2.ToCallMyEvent();

            //task3
            IDictionary dictionary = task3.CreateAndFillDictionary();
            foreach (int key in dictionary.Keys)
                Console.WriteLine(dictionary[key]);


            Console.ReadKey();
        }
    }
}