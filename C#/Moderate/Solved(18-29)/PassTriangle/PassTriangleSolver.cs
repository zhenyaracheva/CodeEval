namespace PassTriangle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PassTriangleSolver
    {
        static void Main(string[] args)
        {
            //DateTime start = DateTime.Now;
            var firstLine = new int[1];
            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();
                firstLine[0] = int.Parse(line);
                line = reader.ReadLine();

                while (line != null)
                {
                    var secondLine = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    var temp = new int[secondLine.Length];

                    for (int i = 0; i < firstLine.Length; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            int sum = firstLine[i] + secondLine[i+j];

                            if (temp[i + j] < sum)
                            {
                                temp[i+j] = sum;
                            }
                        }
                    }

                    firstLine = temp;
                    line = reader.ReadLine();
                }

                Console.WriteLine(firstLine.Max());
                //DateTime end = DateTime.Now;
                //Console.WriteLine(end-start);
            }
        }
    }
}
