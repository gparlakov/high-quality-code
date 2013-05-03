using System;
using System.Linq;

namespace Methods
{
    public struct Point
    {
        public Point(double xCoord, double yCoord) : this()
        {
            this.Xcoord = xCoord;
            this.Ycoord = yCoord;
        }

        public double Xcoord { get; set; }

        public double Ycoord { get; set; }
    }
}