namespace PrimeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class PrimeNumbersSolver
    {
        private static int pN = 0;
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {

                    int n = int.Parse(line);
                    var primes = new List<int>();
                    pN = 0;
                    output.AppendLine(FindPrimes(n, primes));



                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static string FindPrimes(int n, List<int> primes)
        {
            for (int i = 2; i < n; i++)
            {
                if (isPrime(i, primes))
                {
                    primes.Add(i);
                    pN++;
                }
            }

            return string.Join(",", primes);
        }

        private static bool isPrime(int n, List<int> primes)
        {

            int i = 0;
            while (i < pN && primes[i] * primes[i] <= n)
            {
                if (n % primes[i] == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
