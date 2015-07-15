namespace Lowercase
{
    using System;
    using System.IO;
    using System.Text;

    public class LowercaseSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    output.AppendLine(line.ToLower());
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}