using System;
using System.Linq;

namespace Methods
{
    public static class Utilities
    {
        /// <summary>
        /// Converts given digit to a string representration.
        /// </summary>
        /// <param name="number">Digit to convert</param>
        /// <returns>Word representation</returns>
        /// <exception cref="ArgumentException">If given integer is not a digit, but a number</exception>
        public static string DigitAsWord(int number)
        {
            string digitAsWord = null;
            if (number >= 0 && number <= 9)
            {
                string[] digits = new string[]
                {
                    "zero", "one", "three", "four", "five", "six", "seven", "eight", "nine"
                };
                digitAsWord = digits[number];
            }
            else
            {
                throw new ArgumentException(
                    "number",
                    "Argument should be an integer between [0 and 9] inclusive.");
            }

            return digitAsWord;
        }

        /// <summary>
        /// Finds max number in <paramref name="elements"/>.
        /// </summary>
        /// <param name="elements">Set of elements to search in.</param>
        /// <returns>Maximal element in set</returns>
        /// <exception cref="ArgumentNullException">If given argument is null</exception>
        /// <exception cref="ArgumentException">If given arguments set is empty</exception>
        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("elements");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("elements");
            }

            var max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    max = elements[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Prints <paramref name="obj"/> as a two decimal point float literal.
        /// </summary>
        /// <param name="obj">Object to print</param>
        /// <exception cref="FormatException">If obj is not a number</exception>
        public static void PrintFloat(object obj)
        {
            var num = double.Parse(obj.ToString()); // will throw exception if number is not in format
            Console.WriteLine("{0:f2}", num);
        }

        /// <summary>
        /// Prints <paramref name="obj"/> as a two decimal point percent literal.
        /// </summary>
        /// <param name="obj">Object to print</param>
        /// <exception cref="FormatException">If obj is not a number</exception>
        public static void PrintAsPercent(object obj)
        {
            var num = double.Parse(obj.ToString()); // will throw exception if number is not in format
            Console.WriteLine("{0:p2}", num);
        }

        /// <summary>
        /// Will allign <paramref name="obj"/> to a column of <paramref name="columnWidth"/> console <paramref name="columnWidth"/>. 
        /// If <paramref name="columnWidth"/> is negative - aligns to left of column(screen), otherwise to right.
        /// </summary>
        /// <param name="obj">Object to print</param>
        /// <param name="columnWidth">Width of column in whitch to align</param>
        public static void PrintAlligned(object obj, int columnWidth)
        {
            Console.WriteLine("{0," + columnWidth + "}", obj);
        }
    }
}