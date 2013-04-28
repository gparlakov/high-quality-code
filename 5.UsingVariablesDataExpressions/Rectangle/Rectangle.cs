using System;

namespace Figures
{
    /// <summary>
    /// Initializes a new figure rectangle with given width and height. Can calculate its rotated state.
    /// </summary>
    public class Rectangle
    {
        private readonly double width, 
                                height;                

        public double Width
        {
            get { return this.width; }           
        }

        public double Height
        {
            get { return this.height; }
        }        

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Calculates the sides of a rectangle rotated by a given angle and returns the new rectangle
        /// </summary>
        /// <param name="rectangle">The rectangle to rotate</param>
        /// <param name="angleOfRotation">How much to rotate the rectangle in radians (Math.Pi = 90 degrees)</param>
        /// <returns>New rectangle with the calculated sides</returns>
        public static Rectangle GetRotatedRectangle(Rectangle rectangle, double angleOfRotation)
        {
            double rotatedWidth,
                   rotatedHeight,
                   sinOfAngle,
                   cosOfAngle;

            sinOfAngle = Math.Abs(Math.Sin(angleOfRotation));
            cosOfAngle = Math.Abs(Math.Cos(angleOfRotation));

            rotatedWidth = cosOfAngle * rectangle.width + sinOfAngle * rectangle.height;
            rotatedHeight = sinOfAngle * rectangle.width + cosOfAngle * rectangle.height;
            
            Rectangle rotatedRectangle = new Rectangle(rotatedWidth, rotatedHeight);

            return rotatedRectangle;
        }
    }
}
