namespace SumOfDigits
{
    using System;
    using System.Linq;
    using System.IO;

    public class SumOfDigitsSolver
    {
        static void Main(string[] args)
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

                    int result = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        result += line[i] - '0';
                    }
                    Console.WriteLine(result);
                }
            }
        }
    }
}