namespace TwentyFortyEight
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class TwentyFortyEightSolver
    {
        private static int[,] cube;

        public static void Main(string[] args)
        {
            var output = new StringBuilder();

            using (StreamReader reader = File.OpenText(args[0]))
            //using (StreamReader reader = new StreamReader("test5.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var input = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var direction = input[0];
                    ReadInput(input);
                    Move(direction.ToUpper());
                    output.AppendLine(GetOutput(cube));
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static string GetOutput(int[,] cube)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    builder.AppendFormat("{0} ", cube[i, j]);
                }
                builder.Length--;
                builder.Append("|");
            }

            builder.Length--;
            return builder.ToString();
        }

        private static void Move(string direction)
        {
            switch (direction)
            {
                case "RIGHT":
                    LeftRightMove(cube.GetLength(1) - 1, cube.GetLength(1) - 2, 1);
                    break;
                case "LEFT":
                    LeftRightMove(0, -1, -1);
                    break;
                case "UP":
                    UpDownMove(0, -1, -1);
                    break;
                case "DOWN":
                    UpDownMove(cube.GetLength(0) - 1, cube.GetLength(0) - 2, 1);
                    break;
                default: throw new ArgumentException("Wrong direction!");
            }
        }

        private static void UpDownMove(int startFallIndex, int startIndex, int power)
        {
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                bool swaped = false;
                int index = startFallIndex;
                for (int j = 0; j < cube.GetLength(1) - 1; j++)
                {
                    var innerIndex = (startIndex - j) * power;
                    var prev = cube[index, i];
                    var current = cube[innerIndex, i];

                    if (prev == 0 && current != 0)
                    {
                        index = ChangeUpDown(index, 0, i, innerIndex, current, 0);
                    }
                    else if (prev != 0 && prev == current)
                    {
                        if (swaped)
                        {
                            index = ChangeUpDown(index, power * (-1), i, innerIndex, current, 0);                            
                        }
                        else 
                        {
                            index = ChangeUpDown(index, 0, i, innerIndex, current + prev, 0);
                            swaped = true;
                        }
                    }
                    else if (prev != 0 && prev != current && current != 0 && cube[index - power,i] == 0)
                    {
                        index = ChangeUpDown(index, power * (-1), i, innerIndex, current, 0);
                        swaped = false;
                    }
                    else if (prev != 0 && prev != current && current != 0)
                    {
                        index = ChangeUpDown(index, power * (-1), i, innerIndex, prev, current);
                        swaped = false;
                    }
                }
            }
        }

        private static int ChangeUpDown(int index, int change, int firstIndex, int secondIndex, int changeFirst, int changeSecond)
        {
            index = index + change;
            cube[index, firstIndex] = changeFirst;
            cube[secondIndex, firstIndex] = changeSecond;

            return index;
        }

        private static void LeftRightMove(int startFallIndex, int startIndex, int power)
        {
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                bool swaped = false;
                int index = startFallIndex;
                for (int j = 0; j < cube.GetLength(1) - 1; j++)
                {
                    var innerIndex = (startIndex - j) * power;
                    var prev = cube[i, index];
                    var current = cube[i, innerIndex];

                    if (prev == 0 && current != 0)
                    {
                        index = ChangeLeftRight(index, 0, i, innerIndex, current, 0);
                    }
                    else if (prev != 0 && prev == current)
                    {
                        if (swaped)
                        {
                            index = ChangeLeftRight(index, power * (-1), i, innerIndex, current, 0);
                        }
                        else
                        {
                            ChangeLeftRight(index, 0, i, innerIndex, current + prev, 0);
                            swaped = true;
                        }
                    }
                    else if (prev != 0 && prev != current && current != 0 && cube[i, index - power] == 0)
                    {
                        index = ChangeLeftRight(index, power * (-1), i, innerIndex, current, 0);
                        swaped = false;
                    }
                    else if (prev != 0 && prev != current && current != 0)
                    {
                        index = ChangeLeftRight(index, power * (-1), i, innerIndex, prev, current);
                        swaped = false;
                    }
                }
            }
        }

        private static int ChangeLeftRight(int index, int change, int firstIndex, int secondIndex, int changeFirst, int changeSecond)
        {
            index = index + change;
            cube[firstIndex, index] = changeFirst;
            cube[firstIndex, secondIndex] = changeSecond;

            return index;
        }

        private static void ReadInput(string[] input)
        {
            var size = byte.Parse(input[1]);
            var parts = input[2].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            cube = new int[size, size];

            for (int i = 0; i < parts.Length; i++)
            {
                var line = parts[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    cube[i, j] = line[j];
                }
            }
        }
    }
}
