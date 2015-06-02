namespace CardNumberValidation
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class CardNumberValidationSolver
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
                    var numbers = line.Replace(" ", "").ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

                    for (int i = numbers.Length - 2; i >= 0; i -= 2)
                    {
                        numbers[i] = numbers[i] * 2;
                    }

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] > 9)
                        {
                            numbers[i] = ChangeNumber(numbers[i]);
                        }
                    }

                    var sum = numbers.Sum();

                    if (sum % 10 == 0)
                    {
                        output.AppendLine("1");
                    }
                    else
                    {
                        output.AppendLine("0");
                    }

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static int ChangeNumber(int num)
        {
            while (num > 9)
            {
                var separated = num.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
                num = separated.Sum();
            }

            return num;
        }
    }
}
