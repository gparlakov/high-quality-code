namespace Telerik.ILS.Common
{
    using System;
    using System.Linq;

    class TestStringExtensions
    {
        static void Main()
        {
            string text = "tero nerotero nerotero nerotero nero";
            string date = "01.01.2013";

            Console.WriteLine(text.ToDateTime());
            Console.WriteLine(date.ToDateTime());

            Console.WriteLine(text.ToMd5Hash());

            Console.WriteLine(text.ToBoolean());
            Console.WriteLine("1".ToBoolean());
            Console.WriteLine("Да".ToBoolean());
        }
    }
}
