namespace RobotMovements
{
    using System;

    public class RobotMovementsSolver
    {
        public const int Size = 4;
        public static int count = 0;

        public static void Main(string[] args)
        {
            var matrix = new int[RobotMovementsSolver.Size, RobotMovementsSolver.Size];
            var visited = new bool[RobotMovementsSolver.Size, RobotMovementsSolver.Size];
            Solver(matrix, visited, 0, 0);
            Console.WriteLine(count);
        }

        private static void Solver(int[,] matrix, bool[,] visited, int row, int col)
        {
            if (row == RobotMovementsSolver.Size - 1 && col == RobotMovementsSolver.Size-1)
            {
                count++;
                return;
            }

            visited[row, col] = true;

            if (row - 1 >= 0 && !visited[row - 1, col])
            {
                Solver(matrix, visited, row - 1, col);
                visited[row, col] = false;
            }

            if (col - 1 >= 0 && !visited[row, col - 1])
            {
                Solver(matrix, visited, 1, col - 1);
                visited[row, col] = false;
            }

            if (row + 1 < matrix.GetLength(0) && !visited[row + 1, col])
            {
                Solver(matrix, visited, row + 1, col);
                visited[row, col] = false;
            }

            if (col + 1 < matrix.GetLength(1) && !visited[row, col + 1])
            {
                Solver(matrix, visited, row, col + 1);
                visited[row, col] = false;
            }
        }
    }
}
