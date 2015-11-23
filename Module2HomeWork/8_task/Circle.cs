using System;

namespace Module2HomeWork._8_task
{
    class Circle : GeometricShapes
    {
        protected double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public String GetName()
        {
            return base.GetName() + "circle";
        }

        public override double GetSquare()
        {
            return (Math.Pow(radius, 2) * Math.PI);
        }
    }
}