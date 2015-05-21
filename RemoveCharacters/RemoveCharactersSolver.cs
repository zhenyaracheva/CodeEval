namespace RemoveCharacters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class RemoveCharactersSolver
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
                    var lineParts = line.Split(',');
                    var chars = lineParts[1].Trim();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        lineParts[0] = lineParts[0].Replace(chars[i].ToString(), string.Empty); 
                    }

                    output.AppendLine(lineParts[0]);
                    line = reader.ReadLine();
                }
            }
            
            Console.WriteLine(output.ToString().Trim());
        }
    }
}
