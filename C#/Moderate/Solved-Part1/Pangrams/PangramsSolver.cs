namespace Pangrams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class PangramsSolver
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            //  using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var letters = new StringBuilder(PangramsSolver.Alphabet);

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (letters.ToString().Contains(line[i].ToString().ToLower()))
                        {
                            letters.Replace(line[i].ToString().ToLower(), string.Empty);
                        }
                    }

                    if (letters.Length == 0)
                    {
                        Console.WriteLine("NULL");
                    }
                    else
                    {
                        Console.WriteLine(letters);
                    }
                }
            }
        }
    }
}