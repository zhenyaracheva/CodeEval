namespace SpiralPrinting
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class SpiralPrintingSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (var reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    int n = int.Parse(parts[0]);
                    int m = int.Parse(parts[1]);
                    var input = parts[2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var matrix = FillMAtrix(n, m, input);
                    output.AppendLine(PrintSpiralMatrix(matrix));
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static string PrintSpiralMatrix(string[,] matrix)
        {
            var result = new StringBuilder();
            int length = matrix.GetLength(0) * matrix.GetLength(1);
            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            int row = 0;
            int col = 0;
            string direction = "right";

            for (int i = 0; i < length; i++)
            {
                if (direction == "right" && !visited[row, col])
                {
                    visited[row, col] = true;
                    result.AppendFormat("{0} ", matrix[row, col]);
                    col++;
                    if (col >= matrix.GetLength(1) || visited[row, col])
                    {
                        direction = "down";
                        col--;
                        row++;
                    }
                }
                else if (direction == "down" && !visited[row, col])
                {
                    visited[row, col] = true;
                    result.AppendFormat("{0} ", matrix[row, col]);
                    row++;
                    if (row >= matrix.GetLength(0) || visited[row, col])
                    {
                        direction = "left";
                        row--;
                        col--;
                    }
                }
                else if (direction == "left" && !visited[row, col])
                {
                    visited[row, col] = true;
                    result.AppendFormat("{0} ", matrix[row, col]);
                    col--;
                    if (col < 0 || visited[row, col])
                    {
                        direction = "up";
                        col++;
                        row--;
                    }
                }
                else if (direction == "up")
                {
                    visited[row, col] = true;
                    result.AppendFormat("{0} ", matrix[row, col]);
                    row--;
                    if (row < 0 || visited[row, col])
                    {
                        direction = "right";
                        row++;
                        col++;
                    }
                }
            }
            return result.ToString().Trim();
        }

        private static string[,] FillMAtrix(int n, int m, string[] input)
        {
            var matrix = new string[n, m];

            for (int i = 0, index = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = input[index];
                    index++;
                }
            }

            return matrix;
        }
    }
}