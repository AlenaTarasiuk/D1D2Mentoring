using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HomeWork
{
    class task4
    {
        public void Solver()
        {
            List<int> list = new List<int>();
            List<string> listTrans = new List<string>();

            bool? state;

            int sum = 1000;
            int number;
            string operand = "";
            int residue = 0;


            Console.WriteLine("Transaction list ");
            foreach (string element in listTrans)
            {
                Console.WriteLine(element + "\n");
            }


            while (operand != "x")
            {
                Console.Write("Your account has 1000.\nPlease enter operation: \nput money, input +,\nwithdraw money, input -,\nfor exit, input x \n");
                operand = Console.ReadLine();
                Console.Write("Please enter sum ");
                number = Convert.ToInt32(Console.ReadLine());
                switch (operand)
                {
                    case "-":
                        residue = sum - number;
                        state = true;
                        break;
                    case "+":
                        residue = sum + number;
                        state = true;
                        break;
                    default:
                        residue = 0;
                        break;
                }
                list.Add(residue);
                string result = sum.ToString() + " " + operand + " " + number.ToString() + " = " + residue.ToString();
                listTrans.Add(result);
                sum = residue;
            }
        }
    }
}
