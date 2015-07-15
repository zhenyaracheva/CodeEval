namespace TrailingString
{
    using System;
    using System.IO;

    public class TrailingStringSolver
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            // using (StreamReader reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var strings = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var result = '0';

                    if (strings[0].Length >= strings[1].Length)
                    {
                        if (strings[0].Substring(strings[0].Length - strings[1].Length) == strings[1])
                        {
                            result = '1';
                        }
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}