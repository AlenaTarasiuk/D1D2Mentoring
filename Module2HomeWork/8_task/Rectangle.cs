using System;

namespace Module2HomeWork._8_task
{
    class Rectangle : GeometricShapes
    {
        protected double hight, wide;

        public Rectangle(double h, double w)
        {
            hight = h;
            wide = w;
        }

        public String GetName()
        {
            return base.GetName() + "rectangle";
        }

        public override double GetSquare()
        {
            return (hight * wide);
        }
    }
}
