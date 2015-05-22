namespace FirstNonRepeatedCharacter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FirstNonRepeatedCharacterSolver
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
                    var checkedSymbols = new HashSet<char>();
                    bool noUniqueSymbols = true;

                    for (int i = 0; i < line.Length; i++)
                    {
                        bool isUnique = true;
                        char symbol = line[i];

                        for (int j = i + 1; j < line.Length; j++)
                        {
                            if (symbol == line[j] || checkedSymbols.Contains(symbol))
                            {
                                isUnique = false;
                                break;
                            }
                        }


                        if (isUnique && !checkedSymbols.Contains(symbol))
                        {
                            output.AppendLine(symbol.ToString());
                            noUniqueSymbols = false;
                            break;
                        }
                        else
                        {
                            checkedSymbols.Add(symbol);
                        }
                    }

                    if (noUniqueSymbols)
                    {
                        output.AppendLine();
                    }

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
