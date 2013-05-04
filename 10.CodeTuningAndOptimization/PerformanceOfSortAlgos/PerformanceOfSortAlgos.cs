using System;
using System.Linq;
using System.Text;

namespace PerformanceOfSortAlgos
{
    class PerformanceOfSortAlgos
    {
        static void Main()
        {
            string[] letters = GenLettersDictionary();
        }

        private static string[] GenRandomString(int count, string[] dictionary)
        {
            Random randomGenarator = new Random();
            string[] result = new string[count];
            for (int i = 0; i < result.Length; i++)
            {
                int wordsCount = 1 + randomGenarator.Next(10);                
                int dictionaryLength = dictionary.Length;
                StringBuilder adder = new StringBuilder();
                for (int j = 0; j < wordsCount; j++)
                {
                    adder.Append(dictionary[randomGenarator.Next(dictionaryLength)]);
                }

                result[i] = adder.ToString();
            }

            return result;
        }

        private static string[] GenLettersDictionary()
        {
            string[] result = new string[52];
            for (char ch = 'a'; ch <= 'a' + 'z'; ch += (char)2)
            {
                result[ch - 'a'] = ((char)ch).ToString();
                result[ch - 'a' + 'A' - 1] = ((char)(ch + 'a')).ToString();
            }

            return result;
        }
    }
}
