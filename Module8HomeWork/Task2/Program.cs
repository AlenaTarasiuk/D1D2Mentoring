using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassConverter objConverter = new ClassConverter();

            Console.Write("please, enter number and press enter -> ");
            string textNumber = Console.ReadLine();

            objConverter.GetNumberLine(textNumber);
            
            Console.ReadKey();
        }

    }
}
