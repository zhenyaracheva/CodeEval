namespace PascalsTriangle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class PascalsTriangleSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            //using (StreamReader reader = File.OpenText(args[0]))
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    int n = int.Parse(line);

                    output.AppendLine(TakePascaleTriangle(n));
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static string TakePascaleTriangle(int n)
        {
            var builder = new StringBuilder();

            if (n == 1)
            {
                return "1";
            }
            else
            {
                var firstLine = new int[] { 1 };
                builder.Append("1 ");
                int[] secondLine;

                for (int i = 2; i <= n; i++)
                {
                    secondLine = new int[i];
                    secondLine[0] = 1;
                    secondLine[i - 1] = 1;

                    for (int j = 1; j < secondLine.Length - 1; j++)
                    {
                        secondLine[j] = firstLine[j - 1] + firstLine[j];
                    }

                    builder.Append(string.Join(" ", secondLine) + " ");
                    firstLine = secondLine;
                }
            }

            return builder.ToString().Trim();
        }
    }
}
