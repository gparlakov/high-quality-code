using System;
using System.Linq;
using System.Text;

namespace RandomGenerators
{
    public class RandomGenerator
    {
        private readonly Random randomGen;
        /// <summary>
        /// Can generate arrays of random int,double and string(with lenght 1 - 10)
        /// </summary>
        public RandomGenerator()
        {
            this.randomGen = new Random();
        }
        
        public double[] GenRandomDoubles(int count)
        {
            if (count < 0)
            {
                throw new RandomGeneratosException("Passed count of words in GenRandomWords method is non-positive", "GenRandomDoubles");
            }

            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = randomGen.NextDouble() * double.MaxValue;
                if (randomGen.Next(100) < 50)
                {
                    result[i] = -result[i];
                }
            }

            return result;
        }

        public int[] GenRandomInts(int count)
        {
            if (count < 0)
            {
                throw new RandomGeneratosException("Passed count of words in GenRandomWords method is non-positive", "GenRandomInts");
            }

            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = randomGen.Next(int.MinValue, int.MaxValue);
            }

            return result;
        }

        /// <summary>
        /// Takes a dictionary of words and combines them in an array with specified length. Each element is a random long combination of random number(1 - 10) of the words
        /// </summary>
        /// <param name="count">How many word to generate</param>
        /// <param name="dictionary">The base words which will be combined to form new words</param>
        /// <returns></returns>
        public string[] GenRandomWords(int count, string[] dictionary)
        {
            if (count < 0)
            {
                throw new RandomGeneratosException("Passed count of words in GenRandomWords method is non-positive", "GenRandomWords");
            }
            if (dictionary == null && dictionary.Length <= 0)
            {
                throw new RandomGeneratosException("Passed dictionary in GenRandomWords method is null/empty.", "GenRandomWords");
            }

            string[] result = new string[count];
            int dictionaryLength = dictionary.Length;
            for (int i = 0; i < result.Length; i++)
            {
                //how many words in current newWord
                int wordsCount = 1 + randomGen.Next(10);
                StringBuilder adder = new StringBuilder();
                for (int j = 0; j < wordsCount; j++)
                {
                    //append randomly selected words from dictionary 
                    adder.Append(dictionary[randomGen.Next(dictionaryLength)]);
                }

                result[i] = adder.ToString();
            }

            return result;
        }

        /// <summary>
        /// Generates a dictionary of all letters [a-zA-Z] with total of all 52 letters
        /// </summary>
        /// <returns>Array with a string of one letter in each element</returns>
        public string[] GenLettersDictionary()
        {
            int length = 'z' - 'a' + 1;
            string[] result = new string[length * 2];
            for (int i = 0; i < length; i++)
            {
                result[i] = ((char)(i + 'a')).ToString();
                result[i + length] = ((char)(i + 'A')).ToString();
            }

            return result;
        }
    }
}
