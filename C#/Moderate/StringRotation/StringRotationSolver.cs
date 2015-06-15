namespace StringRotation
{
    using System;
    using System.Linq;
    using System.IO;

    public class StringRotationSolver
    {
        public static void Main(string[] args)
        {
           using (StreamReader reader = File.OpenText(args[0]))
           // using (StreamReader reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var parts = line.Split(',');
                    var first = parts[0];
                    var second = parts[1];
                    var index = second.IndexOf(first[0]);
                    var result = first == second ? "True" : "False";

                    if (index > 0 && result== "False")
                    {
                        while (index >= 0)
                        {
                            var temp = second.Substring(index) + second.Substring(0, index);

                            if (first == temp)
                            {
                                result = "True";
                                break;
                            }

                            index = second.IndexOf(first[0], index + 1);
                        }
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}
