namespace ReverseGroups
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public class ReverseGroupsSolver
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

                    var parts = line.Split(';');
                    var numbers = parts[0].Split(',').Select(int.Parse).ToArray();
                    var power = int.Parse(parts[1]);
                    var result = new List<int>();

                    for (int i = 0; i < numbers.Length; i += power)
                    {
                        int next = power + i - 1;
                        if (next < numbers.Length)
                        {
                            for (int j = next; j >= i; j--)
                            {
                                result.Add(numbers[j]);
                            }
                        }
                        else
                        {
                            for (int z = i; z < numbers.Length; z++)
                            {
                                result.Add(numbers[z]);
                            }
                        }
                    }

                    Console.WriteLine(string.Join(",", result));
                }
            }
        }
    }
}
