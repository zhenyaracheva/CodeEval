using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LongestLine
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = new StreamReader("input.txt"))
        {
            var line = reader.ReadLine();
            var output = new List<string>();
            var outputCount = int.Parse(line);

            line = reader.ReadLine();

            while (line != null)
            {
                output.Add(line);
                line = reader.ReadLine();
            }

            var orderedLines = output.OrderByDescending(x => x.Length).ThenBy(x => x);

            foreach (var orderedline in orderedLines)
            {
                Console.WriteLine(orderedline);
                outputCount--;

                if (outputCount == 0)
                {
                    break;
                }
            }
        }
    }
}