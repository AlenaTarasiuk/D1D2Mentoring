using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            task1 objT1 = new task1();
            objT1.ShowInfoAuthor();


            task2 objT2 = new task2();
            string[] strmass = { "sasa", "lfns", "дата" };
            Array.Sort(strmass, objT2.CompareWords);

            task3 objT3 = new task3();
            objT3.Helper();

            task4 objT4 = new task4();
            objT4.Solver();
        }
    }
}
