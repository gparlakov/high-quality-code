using System;

namespace PrintStatistics
{
    /// <summary>
    /// Has method that prints on console the statistics (min,max, average) of a given array of doubles
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Prints max,min average of double[] arr
        /// </summary>
        /// <param name="arr"></param>
        public static void PrintStatistics(double[] arr)
        {
            double max = GetMax(arr);  
            Print("Max", max);

            double min = GetMin(arr);
            Print("Min", min);

            double average = GetAverage(arr);
            Print("Average", average);
        }

        /// <summary>
        /// Calculates max in a geven array of double
        /// </summary>
        /// <param name="arr">The array</param>
        /// <returns>Maximal element in arr</returns>
        public static double GetMax(double[] arr)
        {
            double max = double.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Calculates min in a geven array of double
        /// </summary>
        /// <param name="arr">The array</param>
        /// <returns>Minimal element in arr</returns>
        public static double GetMin(double[] arr)
        {
            double min = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        /// <summary>
        /// Calculates average in a geven array of double
        /// </summary>
        /// <param name="arr">The array</param>
        /// <returns>Average in arr</returns>
        public static double GetAverage(double[] arr)
        {
            double sum = 0;
            int length = arr.Length;
            for (int i = 0; i < length; i++)
            {
                sum += arr[i];
            }

            double average = sum / length;
            return average;
        }

        /// <summary>
        /// Prints on console a given message and a given double value
        /// </summary>
        /// <param name="message">The message to print</param>
        /// <param name="result">The value to print</param>
        private static void Print(string message, double result)
        {
            Console.WriteLine("{0} is: {1}", message, result);
        }
    }
}
