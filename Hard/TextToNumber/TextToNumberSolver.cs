namespace TextToNumber
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class TextToNumberSolver
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
                    var textNumber = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    output.AppendLine(ConvertNumber(textNumber).ToString());
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static int ConvertNumber(string[] textNumber)
        {

            bool isNegative = false;
            var unitsMap = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                                       "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", 
                                       "nineteen" };
            var tensMap = new List<string> { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            var muplitiply = new List<string> { "hundred", "thousand", "million" };

            var result = 0;
            int temp = 0;

            for (int i = 0; i < textNumber.Length; i++)
            {
                var currentPart = textNumber[i];

                if (unitsMap.Contains(currentPart))
                {
                    temp += unitsMap.IndexOf(currentPart);
                }
                else if (tensMap.Contains(currentPart))
                {
                    temp += tensMap.IndexOf(currentPart) * 10;
                }
                else if (currentPart == "hundred")
                {
                    temp *= 100;
                }
                else if (currentPart == "thousand")
                {
                    temp *= 1000;
                    result += temp;
                    temp = 0;
                }
                else if (currentPart == "million")
                {
                    temp *= 1000000;
                    result += temp;
                    temp = 0;
                }
                else if (currentPart == "negative")
                {
                    isNegative = true;
                }
            }

            result += temp;

            if (isNegative)
            {
                result *= (-1);
            }

            return result;
        }
    }
}
