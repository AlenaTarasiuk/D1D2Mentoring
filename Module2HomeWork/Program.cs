using Module2HomeWork._2_5_tasks;
using Module2HomeWork._6_task;
using Module2HomeWork._7_task;
using Module2HomeWork._8_task;
using Module2HomeWork._9_task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.Write("input count number = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Fibonacci: ");
            for (int i = 1; i < n; i++)
                Console.Write("{0}, ", NumbersFibonacciAndFactorial.Fibonacci(i));

            Console.Write("\nFactorial: ");
            for (int i = 1; i < n; i++)
                Console.Write("{0}, ", NumbersFibonacciAndFactorial.Factorial(i));

            //3
            ClassA obj1 = new ClassA();
            ClassA.NestedClass obj2 = new ClassA.NestedClass();

            //4
            Console.WriteLine();
            Key objKey = new Key();
            objKey.Open(true);

            ContactlessKey objConKey = new ContactlessKey();
            objConKey.Open(false);

            MagneticCard objMagCard = new MagneticCard();
            objMagCard.Open(true);

            //2
            //5
            Console.WriteLine("List products:\n");
            Person objCart = new Person();
            Product[] products = { objCart.CreateProduct("pen", 10), objCart.CreateProduct("pencil", 20), objCart.CreateProduct("eraser", 15) };

            foreach (KeyValuePair<string, int> item in objCart.dictionary)
            {
                Console.WriteLine(item.Key.ToString() + "  -  " + item.Value.ToString());
            }
            Console.WriteLine("Count total amount of the order  " + objCart.CountTotalAmountOrder());

            objCart.RemoveItem("pen");
            foreach (KeyValuePair<string, int> item in objCart.dictionary)
            {
                Console.WriteLine(item.Key.ToString() + "  -  " + item.Value.ToString());
            }
            Console.WriteLine("Count total amount of the order  " + objCart.CountTotalAmountOrder());

            //6
            HelperSolution.TransactionByCard();
            HelperSolution.TransactionList();
            HelperSolution.MaxTransaction();
            HelperSolution.MinTransaction();

            //7 
            Solver objSolv = new Solver();
            int area = objSolv.IndicateSizeRectangle();
            Console.WriteLine("number rectangles  " + objSolv.GetNumberRectangles(objSolv.GetSquare()) + "\n");

            //8
            Circle objCircle = new Circle(1.0);
            Console.WriteLine(objCircle.GetName());
            Console.WriteLine("square: " + objCircle.GetSquare());

            Rectangle objRectangle = new Rectangle(4.0, 3.0);
            Console.WriteLine(objRectangle.GetName());
            Console.WriteLine("square: " + objRectangle.GetSquare());

            Triangle objTriangle = new Triangle(5.0, 2.0);
            Console.WriteLine(objTriangle.GetName());
            Console.WriteLine("square: " + objTriangle.GetSquare());

            //9
            ApplicationSettings objConf = ApplicationSettings.Instance;
            Console.WriteLine("\ncount user: " + objConf.countUser);
            Console.WriteLine("user language" + objConf.userLanguage);
            Console.WriteLine("database connect " + objConf.databaseConnect);

            Console.ReadKey();
        }
    }
}