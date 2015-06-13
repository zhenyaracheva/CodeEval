namespace ColumnNames
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ColumnNamesSolver
    {
        private const string Symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    output.AppendLine(GetStandardExcelColumnName(int.Parse(line)));
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        public static string GetStandardExcelColumnName(int oneBasedNumber)
        {
            int zeroBasedNumber = oneBasedNumber - 1;
            int system = ColumnNamesSolver.Symbols.Length;
            var result = new StringBuilder();

            while (oneBasedNumber > system)
            {
                result.Insert(0, Symbols[zeroBasedNumber % system]);

                oneBasedNumber = zeroBasedNumber / system;
                zeroBasedNumber = oneBasedNumber - 1;

            };

            return result.Insert(0, Symbols[zeroBasedNumber]).ToString();
        }
    }
}
