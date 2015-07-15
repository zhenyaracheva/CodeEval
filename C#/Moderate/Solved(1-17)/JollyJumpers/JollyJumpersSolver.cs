namespace JollyJumpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class JollyJumpersSolver
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            // using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var numbers = line.Split(' ').Select(int.Parse).ToArray();
                    var n = numbers[0];
                    var result = new HashSet<int>();
                    var output = "Jolly";

                    for (int j = 1; j < n; j++)
                    {
                        var num = Math.Abs(numbers[j] - numbers[j + 1]);
                        if (num > 0 && num < n)
                        {
                            result.Add(num);
                        }
                    }

                    if (result.Count != n - 1)
                    {
                        output = "Not jolly";
                    }

                    Console.WriteLine(output);
                }
            }
        }
    }
}
