namespace ValidParantheses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ValidParanthesesSolver
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
                    var stack = new Stack<char>();
                    string result = "True";

                    for (int i = 0; i < line.Length; i++)
                    {
                        var current = line[i];

                        if (current=='(' || current=='[' || current== '{')
                        {
                            stack.Push(current);
                        }
                        else if (current == ')' || current == ']' || current == '}')
                        {
                            if (stack.Count == 0)
                            {
                                result = "False";
                                break;
                            }

                            var last = stack.Peek();

                            if (last == '(' && current == ')' || last == '[' && current == ']' || last == '{' && current == '}')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                result = "False";
                                break;
                            }
                        }
                    }

                    if (stack.Count != 0)
                    {
                        result = "False";
                    }

                    output.AppendLine(result);
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
