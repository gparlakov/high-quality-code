using System;

namespace Abstraction
{
    public class Circle : Figure, IPerimeterCalculable, ISurfaceCalculable
    {
        public double Radius { get; set; }

        public Circle(double radius)
            :base(2 * radius, 2 * radius)
        {
            this.Radius = radius;
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
