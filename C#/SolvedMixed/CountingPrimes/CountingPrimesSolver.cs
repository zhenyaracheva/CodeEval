namespace CountingPrimes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class CountingPrimesSolver
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

                    var numbers = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var from = int.Parse(numbers[0]);
                    var to = int.Parse(numbers[1]);

                    output.AppendLine(FindPrimes(to, from).ToString());



                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static int FindPrimes(int to, int from)
        {
            var primes = new List<int>();

            for (int i = from; i <= to; i++)
            {
                if (isPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes.Count;
        }

        private static bool isPrime(int n)
        {
            int checkTo = (int)Math.Sqrt(n);
            int counter = 0;

            for (int i = 1; i <= checkTo; i++)
            {
                if (n % i == 0)
                {
                    counter++;
                    if (counter >= 2)
                    {
                        return false;
                    }
                }
            }
            
            if (counter == 1)
            {
                return true;
            }

            return false;
        }
    }
}
