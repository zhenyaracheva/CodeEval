namespace GameOfLife
{
    using System;
    using System.IO;
    using System.Text;

    public class GameOfLifeSolver
    {
        private const int Lives = 10;
        private const char AliveCell = '*';
        private const char DeadCell = '.';
        public static void Main(string[] args)
        {
             using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("input.txt"))
            {
                char[,] currerntGeneration;
                int n = 0;
                var input = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }

                    n++;
                    input.Append(line);
                }
                currerntGeneration = new char[n, n];
                currerntGeneration = FillMatrix(input, currerntGeneration);

                for (int l = 0; l < GameOfLifeSolver.Lives; l++)
                {
                    var nextGeneration = new char[n, n];

                    for (int i = 0; i < currerntGeneration.GetLength(0); i++)
                    {
                        for (int j = 0; j < nextGeneration.GetLength(1); j++)
                        {
                            int neighbours;

                            if (currerntGeneration[i, j] == GameOfLifeSolver.AliveCell)
                            {
                                neighbours = CountNeighbors(currerntGeneration, i, j, GameOfLifeSolver.AliveCell);

                                if (neighbours < 2)
                                {
                                    nextGeneration[i, j] = GameOfLifeSolver.DeadCell;
                                }
                                else if (neighbours == 2 || neighbours == 3)
                                {
                                    nextGeneration[i, j] = GameOfLifeSolver.AliveCell;
                                }
                                else if (neighbours > 3)
                                {
                                    nextGeneration[i, j] = GameOfLifeSolver.DeadCell;
                                }
                            }
                            else
                            {
                                neighbours = CountNeighbors(currerntGeneration, i, j, GameOfLifeSolver.AliveCell);

                                if (neighbours == 3)
                                {
                                    nextGeneration[i, j] = GameOfLifeSolver.AliveCell;
                                }
                                else
                                {
                                    nextGeneration[i, j] = GameOfLifeSolver.DeadCell;

                                }
                            }
                        }
                    }
                   
                    currerntGeneration = nextGeneration;
                }
                Print(currerntGeneration);
            }
        }

        private static int CountNeighbors(char[,] currerntGeneration, int row, int col, char symbol)
        {
            int counter = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i == row && j == col)
                    {
                        continue;
                    }
                    else if (i >= 0 && i < currerntGeneration.GetLength(0) && j >= 0 && j < currerntGeneration.GetLength(1)
                        && currerntGeneration[i, j] == symbol)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static void Print(char[,] matrix)
        {
            var output = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output.Append(matrix[i, j]);
                }
                output.AppendLine();
            }
            output.Length--;
            Console.WriteLine(output);
        }

        private static char[,] FillMatrix(StringBuilder input, char[,] matrix)
        {
            int index = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[index];
                    index++;
                }
            }

            return matrix;
        }
    }
}