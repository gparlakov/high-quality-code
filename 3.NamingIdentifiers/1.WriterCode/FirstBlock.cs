using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksOfCode
{
    class FirstBlock
    {
        class BooleanWriter
        {
            const int MAX_COUNT = 6;

            class Writer
            {
                public void Write(bool boolean)
                {
                    string boolToString = boolean.ToString();
                    Console.WriteLine(boolToString);
                }
            }

            public static void Main()
            {
                Writer writer = new Writer();
                writer.Write(true);
            }
        }
    }
}
