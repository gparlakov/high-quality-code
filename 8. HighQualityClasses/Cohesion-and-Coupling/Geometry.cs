using System;

namespace CohesionAndCoupling
{
    static class Geometry
    {
        /// <summary>
        /// Calculates distance in 2D space between points with coordinates (<paramref name="x1"/>, <paramref name="y1"/>) and (<paramref name="x2"/>, <paramref name="y2"/>)
        /// </summary>
        /// <param name="x1">Coordinate x of first point</param>
        /// <param name="y1">Coordinate y of first point</param>
        /// <param name="x2">Coordinate x of second point</param>
        /// <param name="y2">Coordinate y of second point</param>
        /// <returns>Distance in 2d</returns>
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        /// Calculates distance in 3D space between points with coordinates (<paramref name="x1"/>, <paramref name="y1"/>, <paramref name="z1"/>) and (<paramref name="x2"/>, <paramref name="y2"/>, <paramref name="z2"/>)
        /// </summary>
        /// <param name="x1">Coordinate x of first point</param>
        /// <param name="y1">Coordinate y of first point</param>
        /// <param name="z1">Coordinate z of first point</param>
        /// <param name="x2">Coordinate x of second point</param>
        /// <param name="y2">Coordinate y of second point</param>
        /// <param name="z2">Coordinate z of second point</param>
        /// <returns></returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        /// <summary>
        /// Calculates volume of an parallelepiped with given <paramref name="width"/>, <paramref name="heigth "/> and <paramref name="depth"/>.
        /// </summary>
        /// <param name="width">Width of parallelepiped</param>
        /// <param name="height">Height of parallelepiped</param>
        /// <param name="depth">Depth of parallelepiped</param>
        /// <returns>Volume </returns>
        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        /// <summary>
        /// Calculates diagonal of a parallelepiped with given <paramref name="width"/>, <paramref name="height"/> and <paramref name="depth"/>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }

        /// <summary>
        /// Calculates diagonal of a given wall in a 3D figure's
        /// </summary>
        /// <param name="wallSideOne">Length of one side of the wall</param>
        /// <param name="wallSideTwo">Length of the other side of the wall</param>
        /// <returns>Length of the segment connectiong start of side one and end of side two</returns>
        public static double CalcDiagonal3D(double wallSideOne, double wallSideTwo)
        {
            double distance = CalcDistance2D(0, 0, wallSideOne, wallSideTwo);
            return distance;
        }
    }
}
