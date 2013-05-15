using System;
using System.IO;

namespace MatrixWalk
{
    public class WalkInMarix
    {
        static void change(ref int dx, ref int dy)
        {
            int[] dirX =
            {
                1,
                1,
                1,
                0,
                -1,
                -1,
                -1,
                0
            };
			
            int[] dirY =
            {
                1,
                0,
                -1,
                -1,
                -1,
                0,
                1,
                1
            };

            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count; 
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0]; 
                return;
            }

            dx = dirX[cd + 1];

            dy = dirY[cd + 1];
        }

        static bool proverka(int[,] arr, int x, int y)
        {
            int[] dirX =
            {
                1,
                1,
                1,
                0,
                -1,
                -1,
                -1,
                0
            };

            int[] dirY =
            {
                1,
                0,
                -1,
                -1,
                -1,
                0,
                1,
                1
            };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) ||
                    x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }
				
                if (y + dirY[i] >= arr.GetLength(0) ||
                    y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                    return true;
            }

            return false;
        }

        static void find_cell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        public static void Main()
        {
            //StringReader stringReader = new StringReader("3" + Environment.NewLine);
            //Console.SetIn(stringReader);
            //var console = Console.Out;
            //StringWriter stringWriter = new StringWriter();
            //Console.SetOut(stringWriter);
            StreamWriter fileWriter = new StreamWriter("../../test.out.in.10.txt");
            Console.SetOut(fileWriter);
            using (fileWriter)
            {

                //Console.WriteLine("Enter a positive number ");
                //int n = ReadNumber();

                //while (n <= 0 || n > 100)
                //{
                //    n = ReadNumber();
                //    Console.WriteLine("You haven't entered a correct positive number");
                //}


                int n = 10;
                int step = n,
                    k = 1,
                    i = 0,
                    j = 0,
                    dx = 1,
                    dy = 1;

                int[,] matrix = new int[n, n];

                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[i, j] = k;

                    if (!proverka(matrix, i, j))
                    {
                        break;
                    }// prekusvame ako sme se zadunili

                    if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                        {
                            change(ref dx, ref dy);
                        }
                    }

                    i += dx;
                    j += dy;
                    k++;
                }

                //for (int p = 0; p < n; p++)
                //{
                //    for (int q = 0; q < n; q++)
                //    {
                //        Console.Write("{0,3}", matrix[p, q]);
                //    }
                //    Console.WriteLine();                
                //}

                find_cell(matrix, out i, out j);

                if (i != 0 && j != 0)
                { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                    dx = 1; dy = 1;

                    while (true)
                    { //malko e kofti tova uslovie, no break-a raboti 100% : )
                        matrix[i, j] = k;

                        if (!proverka(matrix, i, j))
                        {
                            break;
                        }// prekusvame ako sme se zadunili

                        if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                        {
                            while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                                change(ref dx, ref dy);
                        }
                        i += dx; 
                        j += dy; 
                        k++;
                    }
                }

                for (int pp = 0; pp < n; pp++)
                {
                    for (int qq = 0; qq < n; qq++)
                    {
                        Console.Write("{0,5}", matrix[pp, qq]);
                    }

                    Console.WriteLine();
                }


                //Console.SetOut(console);
                //Console.WriteLine(stringWriter.ToString());
            }
        }

        private static int ReadNumber()
        {
            string input = Console.ReadLine();
            int n = 0;
            int.TryParse(input, out n);

            return n;
        }
    }
}