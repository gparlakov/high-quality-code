using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RandomGenerators;

namespace PerformanceOfSortAlgos
{
    class PerformanceOfSortAlgos
    {
        static void Main()
        {
            RandomGenerator random = new RandomGenerator();

            string[] letters = random.GenLettersDictionary();
            string[] randomWords = random.GenRandomWords(100000, letters);
            //foreach (var word in randomWords)
            //{
            //    Console.WriteLine(word);
            //}

            double[] randomDoubles = random.GenRandomDoubles(100000);
            int[] randomInts = random.GenRandomInts(100000);
            Console.WriteLine();
        }       
    }
}
