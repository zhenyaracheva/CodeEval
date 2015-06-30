namespace TheMinistryOfTruth
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class TheMinistryOfTruthSolver
    {
        public static void Main(string[] args)
        {
            /// using (var reader = new StreamReader("input.txt"))
            using (StreamReader reader = File.OpenText(args[0]))           
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var inputSplittedParts = line.Split(';');
                    var text = inputSplittedParts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var searchingWords = inputSplittedParts[1].Split(' ');
                    var output = new StringBuilder();
                    var islastWord = false;
                    var isCorrect = false;
                    var wordIndex = 0;
                    var currentWord = string.Empty;

                    if (wordIndex == searchingWords.Length - 1)
                    {
                        islastWord = true;
                    }

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (wordIndex >= searchingWords.Length)
                        {
                            currentWord = " ";
                        }
                        else
                        {
                            currentWord = searchingWords[wordIndex];
                        }

                        output.Append(PutUnderscoresAndWhitespaces(text[i], currentWord) + " ");
                        
                        if (islastWord && text[i].IndexOf(currentWord) != -1)
                        {
                            isCorrect = true;
                        }

                        if (text[i].IndexOf(currentWord) != -1)
                        {
                            wordIndex++;
                            if (wordIndex == searchingWords.Length - 1)
                            {
                                islastWord = true;
                            }
                        }
                    }

                    if (isCorrect)
                    {
                        Console.WriteLine(output.ToString());
                    }
                    else
                    {
                        Console.WriteLine("I cannot fix history");
                    }
                }
            }
        }

        private static string PutUnderscoresAndWhitespaces(string text, string word)
        {
            var builder = new StringBuilder();
            var index = text.IndexOf(word);

            if (index == -1)
            {
                return new string('_', text.Length);
            }
            else if (index + word.Length == text.Length)
            {
                builder.Append(new string('_', index));
                builder.Append(word);
            }
            else
            {
                builder.Append(new string('_', index));
                builder.Append(word);
                builder.Append(new string('_', text.Length - builder.Length));
            }

            return builder.ToString();
        }
    }
}