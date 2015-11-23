using System;
using System.Collections.Generic;
using System.Linq;

namespace Module2HomeWork._6_task
{
    public static class HelperSolution
    {
        static List<int> list = new List<int>();
        static List<string> listTrans = new List<string>();

        public static void TransactionByCard()
        {       
            int summa = 1000;
            int number;
            string operand = "";
            int residue = 0;

            while (operand != "x"){
                Console.Write("Please enter operation: \nput money, input +,\nwithdraw money, input -,\nfor exit, input x \n");
                operand = Console.ReadLine();
                Console.Write("Please enter summa ");
                number = Convert.ToInt32(Console.ReadLine());
                switch (operand)
                {
                    case "-":
                        residue = summa - number;
                        break;
                    case "+":
                        residue = summa + number;
                        break;

                        residue = 0;
                        break;
                }
                list.Add(residue);
                string result = summa.ToString() + " " + operand + " " + number.ToString() + " = " + residue.ToString();
                listTrans.Add(result);
                summa = residue;
            } 
           
        }

        internal static void TransactionList()
        {
            Console.WriteLine("Transaction list ");
            foreach (string element in listTrans)
            {
                Console.WriteLine(element + "\n");
            }
        }

        internal static void MaxTransaction()
        {
            Console.WriteLine("Max transaction -> " + list.Max().ToString());
        }

        internal static void MinTransaction()
        {
            Console.WriteLine("Min transaction -> " + list.Min().ToString());
        }
    }
}