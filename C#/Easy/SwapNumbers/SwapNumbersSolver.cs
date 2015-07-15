namespace SwapNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class SwapNumbersSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (null == line)
                    {
                        break;
                    }

                    output.AppendLine(SwapNumbers(line));
                }
            }

            Console.WriteLine(output);
        }

        private static string SwapNumbers(string input)
        {
            var builder = new StringBuilder();
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                builder.Append(words[i]);
                char firstNum = currentWord[0];
                char lastNum = currentWord[currentWord.Length - 1];
                builder[0] = lastNum;
                builder[builder.Length - 1] = firstNum;
                words[i] = builder.ToString();
                builder.Clear();
            }

            return string.Join(" ", words);
        }
    }
}
