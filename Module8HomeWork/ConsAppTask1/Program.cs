using System;

namespace ConsAppTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassHelper objHepler = new ClassHelper();
           
            Console.Write("please, enter count of rows and press enter -> ");
            int countRows = Convert.ToInt32(Console.ReadLine());

            objHepler.GetLines(countRows);
            objHepler.PrintFirstSymbolLines();

            Console.Read();
        }
    }
}
