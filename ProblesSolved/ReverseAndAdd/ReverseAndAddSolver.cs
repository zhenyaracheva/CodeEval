namespace ReverseAndAdd
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class ReverseAndAddSolver
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
                    var num = int.Parse(line);
                    int counter = -1;

                    while(true)
                    {
                        counter++;
                        var reversedNumber =int.Parse(string.Join("",(num.ToString().ToCharArray().Reverse())));

                        if (num == reversedNumber)
                        {
                            output.AppendLine(counter +" "+ reversedNumber.ToString());
                            break;
                        }
                        else
                        {
                            num =num+ reversedNumber;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
