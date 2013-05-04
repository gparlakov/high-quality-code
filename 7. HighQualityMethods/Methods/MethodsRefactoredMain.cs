using System;

namespace Methods
{
    public class MethodsRefactoredMain
    {
        private static void Main()
        {
            try
            {
                double x1 = 3;
                double y1 = -1;
                double x2 = 3;
                double y2 = 2.5;

                Point pointA = new Point(x1, y1);
                Point pointB = new Point(x2, y2);
                Point pointC = new Point(5.1, 6.2);

                Line line = new Line(pointA, pointB);

                double sideA = Geometry.CalcDistance(pointA, pointB);
                double sideB = Geometry.CalcDistance(pointB, pointC);
                double sideC = Geometry.CalcDistance(pointC, pointA);
                Geometry.CalcTriangleArea(5,6,7);
                Console.WriteLine(Geometry.CalcTriangleArea(sideA, sideB, sideC));

                Console.WriteLine(Utilities.DigitAsWord(5));

                Console.WriteLine(Utilities.FindMax(3, 4, 6, 7, -9));

                Utilities.PrintFloat(1.3);
                Utilities.PrintAsPercent(0.75);
                Console.Write(".....");
                Utilities.PrintAlligned(2.30, -18);

                Console.WriteLine(Geometry.CalcDistance(pointA, pointB));

                bool horizontal;
                bool vertical;
                horizontal = Geometry.IsHorizontal(line);
                vertical = Geometry.IsVertical(line);
                Console.WriteLine(string.Format("Is line Horizontal? {0}", horizontal));
                Console.WriteLine(string.Format("Is line Vertical? {0}", vertical));

                Student peter = new Student("Peter", "Ivanov", "17.03.1992");
                peter.OtherInfo = string.Format(
                    "From Sofia, born at {0}", 
                    peter.BirthDate);

                Student stella = new Student("Stella", "Markova", "03.11.1993");
                stella.OtherInfo = string.Format(
                    "From Vidin, gamer, high results, born at {0}", 
                    stella.BirthDate);

                Console.WriteLine(
                    "{0} older than {1} -> {2}",
                    peter.FirstName,
                    stella.FirstName,
                    peter.CompareTo(stella));
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error has occured : {0}\n{1}", ex.Message, ex.StackTrace);
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error has occured : {0}\n{1}", ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error has occured : {0}\n{1}", ex.Message, ex.StackTrace);
            }
        }
    }
}