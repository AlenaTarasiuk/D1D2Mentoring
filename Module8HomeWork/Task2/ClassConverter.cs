using System;
using System.Text.RegularExpressions;

namespace Task2
{
    class ClassConverter
    {
        public void GetNumberLine()
        {
            string textNumber = GetLine();
            VerifyNumber(textNumber);
        }

        public void GetNumberLine(string textNumber)
        {
            VerifyNumber(textNumber);
        }

        private void VerifyNumber(string textNumber)
        {
            Regex rx = new Regex(@"^\d+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match match = rx.Match(textNumber);

            try
            {
                Console.WriteLine("Your number is {0}.", ReturnNumber(textNumber));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Input string was null argument!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string was invalid!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        private string GetLine()
        {
            Console.Write("please, enter number and press enter -> ");
            string textNumber = Console.ReadLine();
                return textNumber;
        }

        public int ReturnNumber(string textNumber)
        {
            return Convert.ToInt32(textNumber);
        }
    }
}
