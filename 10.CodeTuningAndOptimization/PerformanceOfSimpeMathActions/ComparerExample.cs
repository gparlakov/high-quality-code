/// <summary>
/// Write a program to compare the performance of add, subtract, 
///increment, multiply, divide for int, long, float, double and decimal values.
/// </summary>

using System;
using System.Diagnostics;
using System.Linq;

namespace PerformanceOfSimpeMathActions
{

    class ComparerExample
    {
        const int Repetitions = 1000000;

        static void Main()
        {
            int value = 1;
            Stopwatch timer = new Stopwatch();
            //once so the dynamic kicks in or something else but it needs this initial step oherwise displays super big results
            Adder(value, ref timer);
            Console.WriteLine("Repetitions {0}", Repetitions);
            Console.WriteLine("Int add time : {0,10} milliseconds", 
                Adder(value, ref timer));
            Console.WriteLine("Long add time : {0,9} milliseconds", 
                Adder((long)value, ref timer));
            Console.WriteLine("Float add time : {0,8} milliseconds", 
                Adder((float)value, ref timer));
            Console.WriteLine("Double add time : {0,7} milliseconds", 
                Adder((double)value, ref timer));
            Console.WriteLine("Decimal add time : {0,6} milliseconds", 
                Adder((decimal)value, ref timer));

            Console.WriteLine("Substractions");
            Console.WriteLine("Int substract time : {0,10} milliseconds", 
                Substarctor(value, ref timer));
            Console.WriteLine("Long substract time : {0,9} milliseconds", 
                Substarctor((long)value, ref timer));
            Console.WriteLine("Float substract time : {0,8} milliseconds", 
                Substarctor((float)value, ref timer));
            Console.WriteLine("Double substract time : {0,7} milliseconds", 
                Substarctor((double)value, ref timer));
            Console.WriteLine("Decimal substract time : {0,6} milliseconds", 
                Substarctor((decimal)value, ref timer));
                        
            Console.WriteLine("Multiplies");
            Console.WriteLine("Int multiply time : {0,10} milliseconds", 
                Multiplier(value, ref timer));
            Console.WriteLine("Long multiply time : {0,9} milliseconds",
                Multiplier((long)value, ref timer));
            Console.WriteLine("Float multiply time : {0,8} milliseconds", 
                Multiplier((float)value, ref timer));
            Console.WriteLine("Double multiply time : {0,7} milliseconds", 
                Multiplier((double)value, ref timer));
            Console.WriteLine("Decimal multiply time : {0,6} milliseconds", 
                Multiplier((decimal)value, ref timer));

            Console.WriteLine("Devides");
            Console.WriteLine("Int devide time : {0,10} milliseconds", 
                Devider(value, ref timer));
            Console.WriteLine("Long devide time : {0,9} milliseconds", 
                Devider((long)value, ref timer));
            Console.WriteLine("Float devide time : {0,8} milliseconds", 
                Devider((float)value, ref timer));
            Console.WriteLine("Double devide time : {0,7} milliseconds", 
                Devider((double)value, ref timer));
            Console.WriteLine("Decimal devide time : {0,6} milliseconds", 
                Devider((decimal)value, ref timer));

        }

        private static long Adder(dynamic step, ref Stopwatch timer)
        {
            dynamic sum = step;
            timer.Reset();
            timer.Start();           
            for (int i = 0; i <= Repetitions; i++)
            {
                sum += step;
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        private static long Substarctor(dynamic step, ref Stopwatch timer)
        {
            dynamic sum = step;
            timer.Reset();
            timer.Start();
            for (int i = 0; i <= Repetitions; i++)
            {
                sum -= step;
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        private static long Multiplier(dynamic step, ref Stopwatch timer)
        {
            dynamic sum = 1;
            timer.Reset();
            timer.Start();
            for (int i = 0; i <= Repetitions; i++)
            {
                sum *= step;
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        private static long Devider(dynamic step, ref Stopwatch timer)
        {
            dynamic sum = 100000000;
            timer.Reset();
            timer.Start();
            for (int i = 0; i <= Repetitions; i++)
            {
                sum /= step;
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}
