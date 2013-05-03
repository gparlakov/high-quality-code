using System;
using System.Linq;

namespace Methods
{
    public static class Geometry
    {        
        
        /// <summary>
        /// Calculates a tringle's area by given three sides
        /// </summary>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <param name="c">Side c</param>
        /// <returns>Area of triange</returns>
        /// <exception cref="ArgumentException">In case <paramref name="a"/> <paramref name="b"/> and <paramref name="c"/> are negative or can't form a triangle</exception>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("a b c", "Arguments should be positive. Passed non-positive argument(s)");
            }

            if (!CanFormTriangle(a, b, c))
            {
                throw new ArgumentException("a b c", "Thees 3 sides cannot form a triangle");
            }

            double perimeterHalf = (a + b + c) / 2;
            double area = Math.Sqrt(
                                    perimeterHalf *
                                    (perimeterHalf - a) *
                                    (perimeterHalf - b) *
                                    (perimeterHalf - c));
            return area;
        }

        public static double CalcDistance(Point x1, Point x2)
        {
            double differenceX = x2.Xcoord - x1.Xcoord;
            double differenceY = x2.Ycoord - x1.Ycoord;
            double distance = Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));
            return distance;
        }

        public static bool IsHorizontal(Line line)
        {
            bool isHorizontal = false;
            double y1 = line.Start.Ycoord;
            double y2 = line.End.Ycoord;
            if (y1 == y2)
            {
                isHorizontal = true;
            }

            return isHorizontal;
        }

        public static bool IsVertical(Line line)
        {
            bool isVertical = false;
            double x1 = line.Start.Xcoord;
            double x2 = line.End.Xcoord;
            if (x1 == x2)
            {
                isVertical = true;
            }

            return isVertical;
        }
                
        private static bool CanFormTriangle(double a, double b, double c)
        {
            bool canFormTriangle = false;
            if ((a + b) > c && (b + c) > a && (a + c) > b)
            {
                canFormTriangle = true;
            }

            return canFormTriangle;
        }
    }
}