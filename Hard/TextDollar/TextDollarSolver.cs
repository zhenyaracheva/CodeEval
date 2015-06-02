namespace TextDollar
{
    using System;
    using System.IO;
    using System.Text;

    public class TextDollarSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (var reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    int number = int.Parse(line);
                    output.AppendLine(ConvertNumberToWord(number) + "Dollars");

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static string ConvertNumberToWord(int number)
        {
            var result = new StringBuilder();

            if (number == 0)
            {
                return "Zero";
            }

            if (number < 0)
            {
                return "Minus" + ConvertNumberToWord(Math.Abs(number));
            }

            if ((number / 1000000000) > 0)
            {
                result.Append(ConvertNumberToWord(number / 1000000000) + "Billion");
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                result.Append(ConvertNumberToWord(number / 1000000) + "Million");
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                result.Append(ConvertNumberToWord(number / 1000) + "Thousand");
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                result.Append(ConvertNumberToWord(number / 100) + "Hundred");
                number %= 100;
            }

            if (number > 0)
            {
                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                       "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", 
                                       "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                {
                    result.Append(unitsMap[number]);
                }
                else
                {
                    result.Append(tensMap[number / 10]);
                    if ((number % 10) > 0)
                    {
                        result.Append(unitsMap[number % 10]);
                    }
                }
            }

            return result.ToString();
        }
    }
}
