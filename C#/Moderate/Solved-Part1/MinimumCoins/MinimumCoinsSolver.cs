namespace MinimumCoins
{
    using System;
    using System.IO;

    public class MinimumCoinsSolver
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    int number = int.Parse(line);
                    int coins = 0;
                    int currentCoin = 5;

                    while (number > 0)
                    {
                        coins += number / currentCoin;
                        number %= currentCoin;
                        currentCoin -= 2;
                    }

                    Console.WriteLine(coins);
                }
            }
        }
    }
}
