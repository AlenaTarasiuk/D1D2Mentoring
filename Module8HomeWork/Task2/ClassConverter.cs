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
    }
}