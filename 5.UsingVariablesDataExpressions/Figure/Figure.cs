using System;

namespace Figures
{
    /// <summary>
    /// Initializes a new figure with given width and height. Can calculate its rotated state.
    /// </summary>
    public class Figure
    {
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        private double width, 
                       height;                

        public double Width
        {
            get 
            { 
                return this.width; 
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rectangle's width should be positive!");
                }
            }
        }

        public double Height
        {
            get 
            { 
                return this.height; 
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rectangle's height should be positive!");
                }
            }
        }   

        /// <summary>
        /// Calculates the sides of a figure rotated by a given angle and returns the new figure
        /// </summary>
        /// <param name="figure">The figure to rotate</param>
        /// <param name="angleOfRotation">How much to rotate the figure in radians (Math.Pi = 90 degrees)</param>
        /// <returns>New figure with the calculated sides</returns>
        public static Figure GetRotatedRectangle(Figure figure, double angleOfRotation)
        {
            double rotatedWidth,
                   rotatedHeight,
                   sinOfAngle,
                   cosOfAngle;

            sinOfAngle = Math.Abs(Math.Sin(angleOfRotation));
            cosOfAngle = Math.Abs(Math.Cos(angleOfRotation));

            rotatedWidth = cosOfAngle * figure.width + sinOfAngle * figure.height;
            rotatedHeight = sinOfAngle * figure.width + cosOfAngle * figure.height;
            
            Figure rotatedFigure = new Figure(rotatedWidth, rotatedHeight);

            return rotatedFigure;
        }
    }
}
