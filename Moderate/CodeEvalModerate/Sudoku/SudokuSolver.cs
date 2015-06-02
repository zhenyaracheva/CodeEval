namespace Sudoku
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class SudokuSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();                

                while (line != null)
                {
                    var result = "True";
                    var sudoku = ReadInput(line);

                    if (!CheckVerticals(sudoku))
                    {
                        result = "False";
                    }
                    else if (!ChekHorizontals(sudoku))
                    {
                        result = "False";
                    }
                    else if (!CheckSquare(sudoku))
                    {
                        result = "False";
                    }

                    output.AppendLine(result);
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static bool CheckSquare(int[,] sudoku)
        {
            int lenght = (int)Math.Sqrt(sudoku.GetLength(0));

            for (int i = 0; i < sudoku.GetLength(0); i += lenght)
            {
                for (int j = 0; j < sudoku.GetLength(1); j += lenght)
                {
                    if (!CheckLittleSquare(i, j, lenght, sudoku))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool CheckLittleSquare(int startRowIndex, int startColIndex, int length, int[,] sudoku)
        {
            var numbers = new List<int>();
            for (int i = startRowIndex; i < startRowIndex + length; i++)
            {
                for (int j = startColIndex; j < startColIndex + length; j++)
                {
                    if (numbers.Contains(sudoku[i, j]))
                    {
                        return false;
                    }

                    numbers.Add(sudoku[i, j]);
                }
            }

            return true;
        }

        private static bool ChekHorizontals(int[,] sudoku)
        {
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                var numbers = new List<int>();

                for (int j = 0; j < sudoku.GetLength(1); j++)
                {
                    if (numbers.Contains(sudoku[i, j]))
                    {
                        return false;
                    }

                    numbers.Add(sudoku[i, j]);
                }
            }

            return true;
        }

        private static bool CheckVerticals(int[,] sudoku)
        {
            for (int i = 0; i < sudoku.GetLength(1); i++)
            {
                var numbers = new List<int>();

                for (int j = 0; j < sudoku.GetLength(0); j++)
                {
                    if (numbers.Contains(sudoku[j, i]))
                    {
                        return false;
                    }

                    numbers.Add(sudoku[j, i]);
                }
            }

            return true;
        }

        private static int[,] ReadInput(string line)
        {
            var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var size = int.Parse(parts[0]);
            var matrix = new int[size, size];
            var numbers = parts[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var index = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = numbers[index];
                    index++;
                }
            }

            return matrix;
        }
    }
}
