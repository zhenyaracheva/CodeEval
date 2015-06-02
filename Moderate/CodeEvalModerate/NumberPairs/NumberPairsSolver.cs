namespace NumberPairs
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class NumberPairsSolver
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
                    var splittedLine = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var numbers = splittedLine[0].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    var sum = int.Parse(splittedLine[1]);
                    var emptyLine = true;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        for (int j = i+1; j < numbers.Length; j++)
                        {
                            if(numbers[i]+ numbers[j]== sum)
                            {
                                output.Append(numbers[i].ToString() + ',' + numbers[j].ToString() + ';');
                                emptyLine = false;
                            }
                        }
                    }

                    if(emptyLine)
                    {
                        output.Append("NULL ");
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
