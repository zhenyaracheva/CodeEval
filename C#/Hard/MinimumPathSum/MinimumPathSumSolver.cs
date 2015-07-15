namespace MinimumPathSum
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class MinimumPathSumSolver
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
                    var n = int.Parse(line);
                    var matrix = ReadMatrix(reader, n);

                    for (int i = 1; i < n; i++)
                    {
                        matrix[0, i] = matrix[0, i] + matrix[0, i - 1];
                        matrix[i, 0] = matrix[i, 0] + matrix[i - 1, 0];
                    }

                    for (int i = 1; i < n; i++)
                    {
                        for (int j = 1; j < n; j++)
                        {
                            matrix[i, j] = Math.Min(matrix[i - 1, j], matrix[i, j - 1]) + matrix[i, j];
                        }
                    }

                    output.AppendLine(matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1].ToString());
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static int[,] ReadMatrix(StreamReader reader, int n)
        {
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = reader.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }
}