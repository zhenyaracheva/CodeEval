namespace HexToDecimal
{
    using System;
    using System.IO;

    public class HexToDecimalSolver
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line =reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    Console.WriteLine(Convert.ToInt32(line,16));
                }
            }
        }
    }
}