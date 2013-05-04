using System;

namespace Abstraction
{
    public class Rectangle : Figure, IPerimeterCalculable, ISurfaceCalculable
    {        
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }
        
        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
