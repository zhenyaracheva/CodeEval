namespace LongestCommonSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LongestCommonSubsequenceSolver
    {
        private static int[,] longest;
        private static StringBuilder result;

        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (var reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    result = new StringBuilder();
                    var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var first = parts[0];
                    var second = parts[1];
                    longest = new int[first.Length + 1, second.Length + 1];
                    LCS(first, second);
                    GetLCS(first, second, first.Length, second.Length);
                    output.AppendLine(result.ToString());
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static void GetLCS(string first, string second, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return;
            }

            if (first[i - 1] == second[j - 1])
            {
                GetLCS(first, second, i - 1, j - 1);
                result.Append(first[i - 1]);
            }
            else if (longest[i, j] == longest[i - 1, j])
            {
                GetLCS(first, second, i - 1, j);
            }
            else
            {
                GetLCS(first, second, i, j - 1);
            }
        }

        private static void LCS(string first, string second)
        {
            for (int i = 1; i <= first.Length; i++)
            {
                longest[i, 0] = 0;
            }

            for (int i = 1; i <= second.Length; i++)
            {
                longest[0, i] = 0;
            }

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        longest[i, j] = longest[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        longest[i, j] = Max(longest[i - 1, j], longest[i, j - 1]);
                    }
                }
            }
        }

        private static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
