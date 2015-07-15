namespace ArrayAbsurdity
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ArrayAbsurditySolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            //using (StreamReader reader = File.OpenText(args[0]))
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var array = parts[1].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    var duplicates = array.GroupBy(x => x)
                                          .Where(g => g.Count() == 2)
                                          .Select(g => g.Key)
                                          .ToList();
                    output.AppendLine(string.Join(" ", duplicates));

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
