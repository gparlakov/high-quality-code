using System;
using System.Linq;
using RandomGenerators;
using System.Collections.Generic;

namespace PerformanceOfSortAlgos
{
    class PerformanceOfSortAlgos
    {
        static void Main()
        {
            RandomGenerator random = new RandomGenerator();

            string[] letters = random.GenLettersDictionary();
            string[] randomWords = random.GenRandomWords(1000, letters);  
            double[] randomDoubles = random.GenRandomDoubles(100000);
            int[] randomInts = random.GenRandomInts(100000);
            Console.WriteLine();

            List<string> sortedWords = QuickSort<string>(randomWords);
            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }

        }

        private static List<T> QuickSort<T>(IList<T> unsorted) where T : IComparable<T>
        {
            if (unsorted.Count <= 1)
            {
                return unsorted.ToList<T>();
            }

            T pivot = unsorted[unsorted.Count /2];
            List<T> left = new List<T>();
            List<T> right = new List<T>();
            for (int i = 0; i < unsorted.Count; i++)
            {
                if (unsorted[i].CompareTo(pivot) <= 0)
                {
                    left.Add(unsorted[i]);
                }
                else
                {
                    right.Add(unsorted[i]);
                }
            }

            left = QuickSort<T>(left);
            right = QuickSort<T>(right);
            left.AddRange(right);

            return left;
        }

    }
}
