namespace DecimalToBinary
{
    using System;
    using System.IO;
    using System.Text;

    public class DecimalToBinarySolver
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
                    int number;
                    bool result = Int32.TryParse(line, out number);
                    if (result)
                    {
                        var binary = Convert.ToString(number, 2);
                        output.AppendLine(binary);
                    }

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
