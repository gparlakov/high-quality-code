using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            try
            {
                //Console.WriteLine(FileNameUtilities.ExtractFileExtension("example")); //throws exception
                Console.WriteLine(FileNameUtilities.ExtractFileExtension("example.pdf"));
                Console.WriteLine(FileNameUtilities.ExtractFileExtension("example.new.pdf"));

                //Console.WriteLine(FileNameUtilities.ExtractFileName("example")); //throws exception
                Console.WriteLine(FileNameUtilities.ExtractFileName("example.pdf"));
                Console.WriteLine(FileNameUtilities.ExtractFileName("example.new.pdf"));

                Console.WriteLine("Distance in the 2D space = {0:f2}",
                    Geometry.CalcDistance2D(1, -2, 3, 4));
                Console.WriteLine("Distance in the 3D space = {0:f2}",
                    Geometry.CalcDistance3D(5, 2, -1, 3, -6, 4));

                double width = 3;
                double height = 4;
                double depth = 5;
                Console.WriteLine("Volume = {0:f2}", Geometry.CalcVolume(width, height, depth));
                Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry.CalcDiagonalXYZ(width, height, depth));
                Console.WriteLine("Diagonal XY = {0:f2}", Geometry.CalcDiagonal3D(width, height));
                Console.WriteLine("Diagonal XZ = {0:f2}", Geometry.CalcDiagonal3D(width, depth));
                Console.WriteLine("Diagonal YZ = {0:f2}", Geometry.CalcDiagonal3D(height, depth));                
            }
            catch(UtilsException ex)
            {
                Console.WriteLine(ex);                
                //throw new ArgumentException("Utilities Exception", ex);
            }
        }
    }
}
