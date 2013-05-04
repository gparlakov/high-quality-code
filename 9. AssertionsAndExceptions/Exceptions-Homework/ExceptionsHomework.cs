using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Exceptions_Homework;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (startIndex < 0 || startIndex > arr.Length)
        {
            string message = string.Format(
                "Passed invalid \"startIndex\" at Subsequence<T>.Should be between 0 and {0}.",
                arr.Length);
            throw new ArgumentException(message);
        }

        if (count <= 0 || count + startIndex > arr.Length)
        {
            string message = string.Format(
                "Passed invalid \"count\" argument at Subsequence<T>. Should be bigger than 0 and less than {0}.",
                arr.Length - startIndex);
            throw new ArgumentException(message);
        }
        
        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        Debug.Assert(result.Count == count,
            "Subsequence<T> failed to generate subsequence of desired count.");
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int countSymbols)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentException(
                "Passed null or empty \"str\" argument at ExtractEnding method.");
        }
        
        if (countSymbols <= 0 || countSymbols > str.Length)
        {
            string message = string.Format(
                "Passed invalid \"countSymbols\" at ExtractEnding method.Should be between 1 and {0}.",
                str.Length);
            throw new ArgumentException(message);
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - countSymbols; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        Debug.Assert(result.Length == countSymbols,
            "Method ExtractEnding failed to generate desired result length ");
        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException(
                "Passed invalid \"number\" argument at CheckPrime method. Should be positive");
        }

        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            //var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0); //Exception because of generating unexpected result
            //Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            //Console.WriteLine(ExtractEnding("Hi", 100)); //exception due to too big count

            Console.WriteLine("Is 23 prime > {0}", CheckPrime(23));
            Console.WriteLine("Is 33 prime > {0}", CheckPrime(33));

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                //new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageResult();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);

            foreach (var exam in peterExams)
            {
                Console.WriteLine("{0} , {1}",exam.Check().Grade, exam.Check().Comments);
            }
        }
        catch (ExamException ex)
        {
            string message = string.Format("{0} at {1}", ex.Message, ex.MethodName);
            if (!string.IsNullOrEmpty(ex.ArgumentName))
            {
                message += string.Format(" argument name: {0}", ex.ArgumentName);
            }

            Console.WriteLine(message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}