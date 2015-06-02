namespace Sudoku2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Sudoku
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
                    var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var sudoku = parts[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    var size = int.Parse(parts[0]);

                    if (!CheckVerticals(sudoku, size))
                    {
                        result = "False";
                    }
                    else if (!ChekHorizontals(sudoku, size))
                    {
                        result = "False";
                    }
                    if (!CheckSquare(sudoku, size))
                    {
                        result = "False";
                    }

                    output.AppendLine(result);
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static bool CheckSquare(int[] sudoku, int size)
        {
            int lenght = (int)Math.Sqrt(size);

            for (int row = 0; row < sudoku.Length; row += size * lenght)
            {
                for (int i = row; i < (size * lenght+row); i += (size * lenght))
                {
                    if (!CheckLittleSquare(i, lenght, size, sudoku))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool CheckLittleSquare(int startRowIndex, int length, int size, int[] sudoku)
        {
            var circles = length;
            var numbers = new List<int>();
            for (int i = startRowIndex; i <= (size * length+ startRowIndex); i += size)
            {
                for (int j = i; j < i + length; j++)
                {
                    if (numbers.Contains(sudoku[j]))
                    {
                        return false;
                    }

                    numbers.Add(sudoku[j]);
                }

                if (numbers.Count == size)
                {
                    numbers = new List<int>();
                    i -= size + length;
                    circles--;
                    if (circles == 0)
                    {
                        return true;
                    }
                }
            }

            return true;
        }

        private static bool ChekHorizontals(int[] sudoku, int size)
        {
            for (int i = 0; i < sudoku.Length; i += size)
            {
                var numbers = new List<int>();
                for (int j = i; j < i + size; j++)
                {
                    if (numbers.Contains(sudoku[j]))
                    {
                        return false;
                    }

                    numbers.Add(sudoku[j]);
                }
            }

            return true;
        }

        private static bool CheckVerticals(int[] sudoku, int size)
        {
            for (int i = 0; i < size; i++)
            {
                var numbers = new List<int>();

                for (int j = i; j < sudoku.Length; j += size)
                {
                    if (numbers.Contains(sudoku[j]))
                    {
                        return false;
                    }

                    numbers.Add(sudoku[j]);
                }
            }

            return true;
        }
    }
}