using System;

namespace ConsAppTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassHelper objHepler = new ClassHelper();
            objHepler.GetLines();
            objHepler.PrintFirstSymbolLines();

            Console.Read();
        }
    }
}
