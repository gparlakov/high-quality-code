using System;
using System.Linq;
using RandomGenerators;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceOfSortAlgos
{
    class PerformanceOfSortAlgos
    {
        static void Main()
        {
            RandomGenerator random = new RandomGenerator();
            
            string[] letters = random.GenLettersDictionary();
            string[] randomWords = random.GenRandomWords(10000, letters);
            string[] randomWordsMore = random.GenRandomWords(30000, letters);
  
            double[] randomDoubles = random.GenRandomDoubles(10000);
            double[] randomDoublesMore = random.GenRandomDoubles(100000);
            
            int[] randomInts = random.GenRandomInts(10000);
            int[] randomIntsMore = random.GenRandomInts(100000);
            Console.WriteLine();
            Stopwatch timer = new Stopwatch();


            ///strings
            StringsTimer(randomWords, randomWordsMore, timer);

            ///int
            IntTimer(randomInts, randomIntsMore, timer);
            
            ///double
            DoubleTimer(randomDoubles, randomDoublesMore, timer);
        }

        private static void DoubleTimer(double[] randomDoubles, double[] randomDoublesMore, Stopwatch timer)
        {
            timer.Restart();
            timer.Start();
            Sorter.QuickSort<double>(randomDoubles);
            timer.Stop();
            Console.WriteLine("Quick sort with 10000 int numbers time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.SelectionSort<double>(randomDoubles);
            timer.Stop();
            Console.WriteLine("Selection sort with 10000 int numbers time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.QuickSort<double>(randomDoublesMore);
            timer.Stop();
            Console.WriteLine("Quick sort with 100000 int numbers time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.SelectionSort<double>(randomDoublesMore);
            timer.Stop();
            Console.WriteLine("Selection sort with 100000 int numbers time : {0}", timer.ElapsedMilliseconds);
        }

        private static void IntTimer(int[] randomInts, int[] randomIntsMore, Stopwatch timer)
        {
            timer.Restart();
            timer.Start();
            Sorter.QuickSort<int>(randomInts);
            timer.Stop();
            Console.WriteLine("Quick sort with 10000 int numbers time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.SelectionSort<int>(randomInts);
            timer.Stop();
            Console.WriteLine("Selection sort with 10000 int numbers time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.QuickSort<int>(randomIntsMore);
            timer.Stop();
            Console.WriteLine("Quick sort with 100000 int numbers time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.SelectionSort<int>(randomIntsMore);
            timer.Stop();
            Console.WriteLine("Selection sort with 100000 int numbers time : {0}", timer.ElapsedMilliseconds);
        }

        private static void StringsTimer(string[] randomWords, string[] randomWordsMore, Stopwatch timer)
        {
            timer.Restart();
            timer.Start();
            Sorter.QuickSort<string>(randomWords);
            timer.Stop();
            Console.WriteLine("Quick sort with 10000 string time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.SelectionSort<string>(randomWords);
            timer.Stop();
            Console.WriteLine("Selection sort with 10000 string time : {0}", timer.ElapsedMilliseconds);

            timer.Restart();
            timer.Start();
            Sorter.QuickSort<string>(randomWordsMore);
            timer.Stop();
            Console.WriteLine("Quick sort with 100000 stringtime : {0}", timer.ElapsedMilliseconds);
            
            ///takes about 2 minutes
            timer.Restart();
            timer.Start();
            Sorter.SelectionSort<string>(randomWordsMore);
            timer.Stop();
            Console.WriteLine("Selection sort with 100000 string numbers time : {0}", timer.ElapsedMilliseconds);
        }
    }
}
