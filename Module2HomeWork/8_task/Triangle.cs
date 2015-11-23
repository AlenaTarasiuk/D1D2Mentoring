using System;

namespace Module2HomeWork._8_task
{
    class Triangle : GeometricShapes
    {
        protected double hight;
        protected double warp;

        public Triangle(double h, double w)
        {
            hight = h;
            warp = w;
        }

        public String GetName()
        {
            return base.GetName() + "triangle";
        }
        
        public override double GetSquare()
        {
            return (0.5 * hight * warp);
        }
    }
}