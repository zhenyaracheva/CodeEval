namespace TheLabyrinth
{
    using System;
    using System.IO;
    using System.Text;

    public class TheLabyrinthSolver
    {
        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            // using (StreamReader reader = File.OpenText(args[0]))
            using (var reader = new StreamReader("test1.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
