/// <summary>
/// Write a program to compare the performance of square root, 
/// natural logarithm, sinus for float, double and decimal values.
/// </summary>

using System;
using System.Diagnostics;
using System.Linq;

namespace PerformanceMathMethods
{
    class PerformanceMathMethods
    {
        const int Repetitions = 1000000;

        static void Main()
        {
            Stopwatch timer = new Stopwatch();
            float value = 500000;
            Sqrt(value, ref timer);
            Console.WriteLine(
                "Time in milliseconds for Sqrt {0} times with float," + 
                " double and decimal(in that order) values.",
                Repetitions);
            Console.WriteLine(Sqrt(value, ref timer));
            Console.WriteLine(Sqrt((double)value, ref timer));
            Console.WriteLine(Sqrt((decimal)value, ref timer));

            Console.WriteLine(
                "Time in milliseconds for Natural algorithm {0} times with float," +
                " double and decimal(in that order) values.",
                Repetitions); Console.WriteLine(NaturalLogarithm(value, ref timer));
            Console.WriteLine(NaturalLogarithm((double)value, ref timer));
            Console.WriteLine(NaturalLogarithm((decimal)value, ref timer));

            Console.WriteLine(
                "Time in milliseconds for Sinus {0} times with float," +
                " double and decimal(in that order) values.",
                Repetitions); Console.WriteLine(Sin(value, ref timer));
            Console.WriteLine(Sin((double)value, ref timer));
            Console.WriteLine(Sin((decimal)value, ref timer));
        }

        private static long Sqrt(dynamic value, ref Stopwatch timer)
        {
            dynamic result = value;
            timer.Reset();
            timer.Start();
            for (int i = 0; i <= Repetitions; i++)
            {
                result = Math.Sqrt((double)value);
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        private static long NaturalLogarithm(dynamic value, ref Stopwatch timer)
        {
            dynamic result = value;
            timer.Reset();
            timer.Start();
            for (int i = 0; i <= Repetitions; i++)
            {
                result = Math.Log((double)value, Math.E);
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        private static long Sin(dynamic value, ref Stopwatch timer)
        {
            dynamic result = value;
            timer.Reset();
            timer.Start();
            for (int i = 0; i <= Repetitions; i++)
            {
                result = Math.Sin((double)value);
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

    }
}
