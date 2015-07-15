namespace InteruptedBubbleSort
{
    using System;
    using System.Linq;
    using System.IO;

    public class InteruptedBubleSortSolver
    {
        public static void Main(string[] args)
        {
            // using (StreamReader reader = File.OpenText(args[0]))
            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var parts = line.Split('|');
                    var numbers = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                    var iterrations = long.Parse(parts[1]);
                    var tempSwapIndex = numbers.Length - 1;
                    var lastSwapIndex = numbers.Length - 1;


                    if (numbers.Length > 1)
                    {
                        for (long i = 0; i < iterrations; i++)
                        {
                            bool notChanged = true;

                            for (int j = 0; j < lastSwapIndex; j++)
                            {
                                if (numbers[j] > numbers[j + 1])
                                {
                                    var temp = numbers[j];
                                    numbers[j] = numbers[j + 1];
                                    numbers[j + 1] = temp;
                                    tempSwapIndex = j;
                                    notChanged = false;
                                }
                            }

                            if (notChanged)
                            {
                                break;
                            }

                            lastSwapIndex = tempSwapIndex;
                        }
                    }

                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}