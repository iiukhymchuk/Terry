using System;
using System.Collections.Generic;

namespace Terry
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetMatrix();
            PrintMatrix(matrix);
            Console.WriteLine("What is the start node?");
            var input = Console.ReadLine();
            if (input != "0" && input != "1" && input != "2" && input != "3")
                throw new InvalidOperationException();
            int start = int.Parse(input);
            Console.WriteLine("What is the finish node?");
            var input2 = Console.ReadLine();
            if (input2 != "0" && input2 != "1" && input2 != "2" && input2 != "3")
                throw new InvalidOperationException();
            int finish = int.Parse(input2);

            int row = start;
            int col = 0;

            var stack = new List<int>();
            while (true)
            {
                if (matrix[row][col] == 1)
                {
                    stack.Add(row);

                    matrix[row][col] = matrix[col][row] = 0;

                    row = col;
                    col = 0;

                    if (row == finish)
                    {
                        Console.WriteLine("The path is:");
                        foreach (var item in stack)
                        {
                            Console.Write($"{item}->");
                        }
                        Console.Write($"{finish}");
                        break;
                    }
                }
                else
                {
                    if (++col == matrix.Length)
                    {
                        if (stack.Count == 0)
                        {
                            Console.WriteLine("There is no path between nodes");
                            break;
                        }
                        // stack pop in two method calls
                        row = stack[stack.Count - 1]; stack.RemoveAt(stack.Count - 1);
                        col = 0;
                    }
                }
            }
        }

        static int[][] GetMatrix()
        {
            Console.WriteLine("Enter 4 X 4 matrix.");
            int[][] matrix = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                matrix[i] = new int[4];
                Console.WriteLine($"->{i} row");
                for (int j = 0; j < 4; j++)
                {
                    var input = Console.ReadLine();

                    if (input != "1" && input != "0")
                        throw new InvalidOperationException("matrix should consist of 0 or 1 values.");
                    matrix[i][j] = int.Parse(input);
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[][] matrix)
        {
            Console.WriteLine("Your matrix is:");
            for (int i = 0; i < matrix.Length; i++)
            {
                var row = matrix[i];
                for (int j = 0; j < row.Length; j++)
                {
                    Console.Write($"{row[j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
