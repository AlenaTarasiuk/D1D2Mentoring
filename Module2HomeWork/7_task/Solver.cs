using System;

namespace Module2HomeWork._7_task
{
    class Solver
    {
        int x;
        int y;
        int z;

        public int GetSquare()
        {
            Console.Write("input square ");
            return int.Parse(Console.ReadLine());
        }

        public int IndicateSizeRectangle()
        {
            Console.Write("\ninput side ectangles: \nx=");
            x = int.Parse(Console.ReadLine());

            Console.Write("y=");
            y = int.Parse(Console.ReadLine());

            Console.Write("z=");
            z = int.Parse(Console.ReadLine());

            return x * y * z;
        }

        public int GetNumberRectangles(int square)
        {
            return (square /( 2 * (y * z + x * y + x * z)));
 
        }

    }
}
