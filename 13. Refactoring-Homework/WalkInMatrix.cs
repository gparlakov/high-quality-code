using System;
using System.IO;

namespace MatrixWalk
{
    public class WalkInMatrix
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            int n = ReadNumber();

            while (n <= 0 || n > 100)
            {
                n = ReadNumber();
                Console.WriteLine("You haven't entered a correct positive number");
            }

            int nextNumber = 1,
                i = 0,
                j = 0,
                dx = 1,
                dy = 1;

            int[,] matrix = new int[n, n];

            //first fills the diagonal and walls and upper triangle
            while (true)
            {
                
                matrix[i, j] = nextNumber;

                if (IsDeadEnd(matrix, i, j))
                {
                    nextNumber++;
                    break;
                }

                UpdateDirection(i, n, j, matrix, ref dx, ref dy);

                i += dx;
                j += dy;
                nextNumber++;
            }

            //finds an empty cell from the other triangle
            FindFirstEmptyCell(matrix, out i, out j);

            if (i != 0 && j != 0)
            { 
                dx = 1; dy = 1;

                while (true)
                { 
                    matrix[i, j] = nextNumber;

                    if (IsDeadEnd(matrix, i, j))
                    {
                        break;
                    }

                    UpdateDirection(i, n, j, matrix, ref dx, ref dy);

                    i += dx;
                    j += dy;
                    nextNumber++;
                }
            }

            //printout the matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,6}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsDeadEnd(int[,] arr, int x, int y)
        {
            int[] dirX = {1, 1, 1, 0, -1, -1, -1, 0};

            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1};

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            bool isDeadEnd = true;

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    isDeadEnd = false;
                }
            }

            return isDeadEnd;
        }

        static void FindFirstEmptyCell(int[,] arr, out int x, out int y)
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

        private static void UpdateDirection(int i, int n, int j, int[,] matrix, ref int dx, ref int dy)
        {
            if (!IsInsideMatrix(matrix, i + dx, j + dy)|| matrix[i + dx, j + dy] != 0)
            {
                while (!IsInsideMatrix(matrix, i + dx, j + dy) || matrix[i + dx, j + dy] != 0)
                {
                    ChangeDirection(ref dx, ref dy);
                }
            }
        }

        static bool IsInsideMatrix(int[,] matrix, int x, int y)
        {
            bool isInsideMatrix = true;
            if (x < 0 || x >= matrix.GetLength(0) || y < 0 || y >= matrix.GetLength(1))
            {
                isInsideMatrix = false;
            }

            return isInsideMatrix;
        }


        static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };

            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

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

        private static int ReadNumber()
        {
            string input = Console.ReadLine();
            int n = 0;
            int.TryParse(input, out n);

            return n;
        }


    }
}