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

            try
            {
                Console.WriteLine("Your number is {0}.", objConverter.GetNumber(textNumber));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Input string was null argument!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string was invalid!");
            }

            Console.ReadKey();
        }

    }
}
