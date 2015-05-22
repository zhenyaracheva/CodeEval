namespace MthToLastElement
{
    using System;
    using System.IO;
    using System.Text;

    public class MthToLastElementSolver
    {
       public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var currentLine = line.Split(' ');
                    var index = int.Parse(currentLine[currentLine.Length - 1]);
                    
                    if(index < currentLine.Length)
                    {
                        output.AppendLine(currentLine[currentLine.Length - index - 1]);
                    }

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
