namespace FlaviusJosephus
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FlaviusJosephusSolver
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
                    var parts = line.Split(',');
                    var people = int.Parse(parts[0]);
                    var badLuck = int.Parse(parts[1])-1;
                    var killed = new bool[people];
                    var output = new HashSet<int>();
                    var index = badLuck - 1;
                    var nextPerson = 0;

                    for (int i = 0; i < people; i++)
                    {
                        if (!killed.Any(x => x == false))
                        {
                            Console.WriteLine(string.Join(" ", output));
                            break;
                        }

                        if (!killed[i])
                        {
                            if (nextPerson == badLuck)
                            {
                                killed[i] = true;
                                output.Add(i);
                                nextPerson = 0;
                            }
                            else
                            {
                                nextPerson++;
                            }
                        }

                        if (i == people - 1)
                        {
                            i = -1;
                        }
                    }
                }
            }
        }
    }
}
