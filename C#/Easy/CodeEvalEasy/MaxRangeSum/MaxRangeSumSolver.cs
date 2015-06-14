namespace MaxRangeSum
{
    using System;
    using System.IO;
    using System.Linq;

    public class MaxRangeSumSolver
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            //using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var input = line.Split(';');
                    var days = int.Parse(input[0]);
                    var numbers = input[1].Split(' ').Select(int.Parse).ToArray();
                    var max = int.MinValue;

                    for (int i = 0; i <= numbers.Length - days; i++)
                    {
                        var sum = 0;
                        for (int j = i; j < i + days; j++)
                        {
                            sum += numbers[j];
                        }

                        if (max < sum)
                        {
                            max = sum;
                        }
                    }

                    if (max < 0)
                    {
                        max = 0;
                    }

                    Console.WriteLine(max);
                }
            }
        }
    }
}
