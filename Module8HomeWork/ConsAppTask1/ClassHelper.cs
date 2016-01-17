using System;
using System.Collections.Generic;

namespace ConsAppTask1
{
    public class ClassHelper
    {
        public List<string> listRows = new List<string>();

        public void PrintFirstSymbolLines()
        {
            foreach (string str in listRows)
                Console.WriteLine(ReturnFirstSymbolLine(str));
        }

        public void GetLines()
        {
            try
            {
                int countRows = GetCountLines();
                for (int i = 0; i < countRows; i++)
                    listRows.Add(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine("error: {0}", e.Message);
            }
        }

        private int GetCountLines()
        {
            Console.Write("please, enter count of rows and press enter -> ");
            int countRows = Convert.ToInt32(Console.ReadLine());
            return countRows;
        }

        public string ReturnFirstSymbolLine(string str)
        {
            try
            {
                str = str.Remove(1, str.Length - 1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("You entered empty line!");
            }
            return str;
        }
    }
}