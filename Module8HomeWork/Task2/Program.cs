using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassConverter objConverter = new ClassConverter();

            objConverter.ConvertNumber(objConverter.InputNumber());
            Console.ReadKey();
        }



    }
}
