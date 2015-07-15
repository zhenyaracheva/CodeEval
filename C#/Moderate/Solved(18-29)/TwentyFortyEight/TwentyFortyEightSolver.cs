namespace TwentyFortyEight
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Solver2048
    {
        public static void Main(string[] args)
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

                    var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var gameBoard = GetGameBoard(int.Parse(parts[1]), parts[2]);
                    var direction = parts[0];
                    Move(gameBoard, direction);
                    PrintGameField(gameBoard);
                }
            }
        }

        private static void PrintGameField(int[,] gameBoard)
        {
            var output = new StringBuilder();

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    output.Append(gameBoard[i, j].ToString() + ' ');
                }
                output.Length--;
                output.Append('|');
            }

            output.Length--;
            Console.WriteLine(output);
        }

        private static int[,] GetGameBoard(int size, string input)
        {
            var field = new int[size, size];
            var numbersAsString = input.Split('|');
            for (int row = 0; row < size; row++)
            {
                var numbers = numbersAsString[row].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = numbers[col];
                }
            }

            return field;
        }

        private static int[,] Move(int[,] gameBoard, string direction)
        {
            if (direction == "RIGHT")
            {
                return MoveRight(gameBoard);
            }
            else if (direction == "LEFT")
            {
                return MoveLeft(gameBoard);
            }
            else if (direction == "UP")
            {
                return MoveUp(gameBoard);
            }
            else if (direction == "DOWN")
            {
                return MoveDown(gameBoard);
            }
            else
            {
                throw new ArgumentException("Invalid direction!");
            }
        }

        private static int[,] MoveDown(int[,] gameBoard)
        {
            for (int col = 0; col < gameBoard.GetLength(1); col++)
            {
                var liderPositionRow = gameBoard.GetLength(1) - 1;
                var liderValue = gameBoard[liderPositionRow, col];

                for (int row = gameBoard.GetLength(1) - 2; row >= 0; row--)
                {
                    if (liderValue != 0 && liderValue == gameBoard[row, col])
                    {
                        gameBoard[liderPositionRow, col] = liderValue + liderValue;
                        gameBoard[row, col] = 0;
                        liderPositionRow--;
                        liderValue = gameBoard[liderPositionRow, col];
                    }
                    else if (liderValue == 0 && gameBoard[row, col] != 0)
                    {
                        gameBoard[liderPositionRow, col] = gameBoard[row, col];
                        liderValue = gameBoard[row, col];
                        gameBoard[row, col] = 0;

                    }
                    else if (liderValue != 0 && gameBoard[row, col] != 0)
                    {
                        liderPositionRow--;
                        if (liderPositionRow != row)
                        {
                            gameBoard[liderPositionRow, col] = gameBoard[row, col];
                            liderValue = gameBoard[row, col];
                            gameBoard[row, col] = 0;
                        }
                        else
                        {
                            liderValue = gameBoard[row, col];
                        }
                    }
                }
            }

            return gameBoard;
        }

        private static int[,] MoveUp(int[,] gameBoard)
        {
            for (int col = 0; col < gameBoard.GetLength(1); col++)
            {
                var liderPositionRow = 0;
                var liderValue = gameBoard[liderPositionRow, col];

                for (int row = 1; row < gameBoard.GetLength(0); row++)
                {
                    if (liderValue != 0 && liderValue == gameBoard[row, col])
                    {
                        gameBoard[liderPositionRow, col] = liderValue + liderValue;
                        gameBoard[row, col] = 0;
                        liderPositionRow++;
                        liderValue = gameBoard[liderPositionRow, col];
                    }
                    else if (liderValue == 0 && gameBoard[row, col] != 0)
                    {
                        gameBoard[liderPositionRow, col] = gameBoard[row, col];
                        liderValue = gameBoard[row, col];
                        gameBoard[row, col] = 0;

                    }
                    else if (liderValue != 0 && gameBoard[row, col] != 0)
                    {
                        liderPositionRow++;
                        if (liderPositionRow != row)
                        {
                            gameBoard[liderPositionRow, col] = gameBoard[row, col];
                            liderValue = gameBoard[row, col];
                            gameBoard[row, col] = 0;
                        }
                        else
                        {
                            liderValue = gameBoard[row, col];
                        }
                    }
                }
            }

            return gameBoard;
        }

        private static int[,] MoveLeft(int[,] gameBoard)
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                var liderPositionCol = 0;
                var liderValue = gameBoard[row, liderPositionCol];

                for (int col = 1; col < gameBoard.GetLength(1); col++)
                {
                    if (liderValue != 0 && liderValue == gameBoard[row, col])
                    {
                        gameBoard[row, liderPositionCol] = liderValue + liderValue;
                        gameBoard[row, col] = 0;
                        liderPositionCol++;
                        liderValue = gameBoard[row, liderPositionCol];
                    }
                    else if (liderValue == 0 && gameBoard[row, col] != 0)
                    {
                        gameBoard[row, liderPositionCol] = gameBoard[row, col];
                        liderValue = gameBoard[row, col];
                        gameBoard[row, col] = 0;

                    }
                    else if (liderValue != 0 && gameBoard[row, col] != 0)
                    {
                        liderPositionCol++;
                        if (liderPositionCol != col)
                        {
                            gameBoard[row, liderPositionCol] = gameBoard[row, col];
                            liderValue = gameBoard[row, col];
                            gameBoard[row, col] = 0;
                        }
                        else
                        {
                            liderValue = gameBoard[row, col];
                        }
                    }
                }
            }

            return gameBoard;
        }

        private static int[,] MoveRight(int[,] gameBoard)
        {

            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                var liderPositionCol = gameBoard.GetLength(0) - 1;
                var liderValue = gameBoard[row, liderPositionCol];

                for (int col = gameBoard.GetLength(1) - 2; col >= 0; col--)
                {
                    if (liderValue != 0 && liderValue == gameBoard[row, col])
                    {
                        gameBoard[row, liderPositionCol] = liderValue + liderValue;
                        gameBoard[row, col] = 0;
                        liderPositionCol--;
                        liderValue = gameBoard[row, liderPositionCol];
                    }
                    else if (liderValue == 0 && gameBoard[row, col] != 0)
                    {
                        gameBoard[row, liderPositionCol] = gameBoard[row, col];
                        liderValue = gameBoard[row, col];
                        gameBoard[row, col] = 0;

                    }
                    else if (liderValue != 0 && gameBoard[row, col] != 0)
                    {
                        liderPositionCol--;
                        if (liderPositionCol != col)
                        {
                            gameBoard[row, liderPositionCol] = gameBoard[row, col];
                            liderValue = gameBoard[row, col];
                            gameBoard[row, col] = 0;
                        }
                        else
                        {
                            liderValue = gameBoard[row, col];
                        }
                    }
                }
            }

            return gameBoard;
        }
    }
}
