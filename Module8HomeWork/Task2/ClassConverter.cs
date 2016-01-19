using System;
using System.Text.RegularExpressions;

namespace Task2
{
    class ClassConverter
    {
        public int GetNumber(string textNumber)
        {
            char[] mass;

            if (textNumber == null) throw new ArgumentNullException();
            mass = textNumber.ToCharArray(0, textNumber.Length);

            for (int i = 0; i < mass.Length; i++)
                if (Char.IsDigit(mass[i])==false) throw new FormatException();

            int number = 0;

            for (int i = 0; i < mass.Length; i++)
                number += (int)Math.Pow(10, textNumber.Length - i - 1) * (int)Char.GetNumericValue(mass[i]);

            return number;
        }

        public void ConvertNumber(string textNumber)
        {
            try
            {
                Console.WriteLine("Your number is {0}.", GetNumber(textNumber));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Input string was null argument!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string was invalid!");
            }
        }

        public string InputNumber()
        {
            Console.Write("please, enter number and press enter -> ");
            string textNumber = Console.ReadLine();
                return textNumber;
        }
    }
}