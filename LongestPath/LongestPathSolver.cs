namespace LongestPath
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class LongestPathSolver
    {
        private const int MAX_SIZE_MATRIX = 6;

        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            //using (StreamReader reader = File.OpenText(args[0]))
            using (StreamReader reader = new StreamReader("test.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var matrix = ReadInput(line);
                    var countMatrix = new HashSet<char>[matrix.GetLength(0), matrix.GetLength(1)];


                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            var current = matrix[i, j];

                            if (i - 1 >= 0 && j - 1 >= 0)
                            {
                                var maxSet = countMatrix[i-1,j].Count>

                                countMatrix[i,i].UnionWith()
                            }
                            else if (i - 1 < 0 && j - 1 < 0)
                            {
                                countMatrix[0, 0].Add(matrix[0, 0]);
                            }

                        }
                    }


                    line = reader.ReadLine();
                }
            }
        }

        //remove me after
        //private static void FindLenght(int i, int j, int currentLenght)
        //{
        //    if (elements.Contains(matrix[i, j]))
        //    {
        //        if (currentLenght > maxLenght)
        //        {
        //             maxLenght = currentLenght;
        //            return;
        //        }               
        //    }

        //    currentLenght++;
        //    elements.Add(matrix[i, j]);

        //    if (i + 1 < matrix.GetLength(0))
        //    {
        //        FindLenght(i + 1, j, currentLenght);
        //    }

        //    if (i - 1 >= 0)
        //    {
        //        FindLenght(i - 1, j, currentLenght);
        //    }
        //    if (j + 1 < matrix.GetLength(1))
        //    {
        //        FindLenght(i, j + 1, currentLenght);
        //    }

        //    if (j - 1 >= 0)
        //    {
        //        FindLenght(i, j - 1, currentLenght);
        //    }
        //    //may be not here!
        //    elements.Remove(matrix[i, j]);
        //    currentLenght--;
        //}

        private static char[,] ReadInput(string line)
        {
            int size = 0;

            for (int i = LongestPathSolver.MAX_SIZE_MATRIX; i >= 0; i--)
            {
                if (line.Length % i == 0)
                {
                    size = i;
                    break;
                }
            }

            var matrix = new char[size, size];
            int counter = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = line[counter];
                    counter++;
                }
            }

            return matrix;
        }
    }
}
