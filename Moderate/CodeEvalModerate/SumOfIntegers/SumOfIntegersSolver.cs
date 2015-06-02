namespace SumOfIntegers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class SumOfIntegersSolver
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
                    var array = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    var maxSum = int.MinValue;

                    for (int i = 0; i < array.Length; i++)
                    {
                        var currentSum = 0;

                        for (int j = i; j < array.Length; j++)
                        {
                            currentSum += array[j];
                            if (maxSum < currentSum)
                            {
                                maxSum = currentSum;
                            }
                        }
                    }
                    output.AppendLine(maxSum.ToString());
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
