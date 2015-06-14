namespace StringMask
{
    using System;
    using System.IO;
    using System.Text;

    public class StringMaskSolver
    {
        static void Main(string[] args)
        {
            //using (StreamReader reader = File.OpenText(args[0]))
             using (StreamReader reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    var parts = line.Split(' ');
                    var result = new StringBuilder();

                    for (int i = 0; i < parts[0].Length; i++)
                    {
                        if (parts[1][i] == '1')
                        {
                            result.Append(parts[0][i].ToString().ToUpper());
                        }
                        else
                        {
                            result.Append(parts[0][i].ToString());
                        }
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}