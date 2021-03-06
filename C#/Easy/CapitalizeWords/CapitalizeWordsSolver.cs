﻿namespace CapitalizeWords
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class CapitalizeWordsSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        output.Append(words[i].First().ToString().ToUpper() + words[i].Substring(1) + ' ');
                    }
                    output.Length--;
                    output.AppendLine();
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine(output.ToString().Trim());
        }
    }
}
