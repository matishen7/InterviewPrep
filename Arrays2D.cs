using System;
using System.Numerics;

namespace ConsoleApp1
{
    internal static class Arrays2D
    {
        private static int[][] directions = new int[][] {
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}};

        public static bool Exist(char[][] board, string word)
        {
            int currentRow = 0, currentColumn = 0;
            for (int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                var nextCharacterCoordinates = FindNextCharacter(currentChar, board, currentRow, currentColumn);
                if (nextCharacterCoordinates.i == -1 && nextCharacterCoordinates.j == -1) return false;
                currentRow = nextCharacterCoordinates.i; currentColumn = nextCharacterCoordinates.j;
            }

            return true;
        }

        static (int i, int j) FindNextCharacter(char cc, char[][] matrix, int currentRow, int currentColumn)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];
                var nextRow = currentRow + currentDirection[0];
                var nextCol = currentColumn + currentDirection[1];
                if (matrix[nextRow][nextCol] == cc) return (nextRow, nextCol);
            }

            return (-1, -1);
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {

            var list = new List<int>();
            int m = matrix.Length, n = matrix[0].Length;
            int currRow = 0;
            int currCol = 0;
            var currDirection = 0;
            while (list.Count < m * n)
            {
                list.Add(matrix[currRow][currCol]);
                matrix[currRow][currCol] = 1000;// set as seen
                int nextRow = currRow + directions[currDirection][0];
                int nextCol = currCol + directions[currDirection][1];
                if (nextRow < 0 || nextRow >= m|| nextCol < 0 || nextCol >= n || matrix[nextRow][nextCol] == 1000)
                    currDirection = (currDirection + 1) % 4;// change direction

                currRow += directions[currDirection][0]; //move to next element according to direction 
                currCol += directions[currDirection][1];
            }

            return list;
        }

        public static void SetZeroes(int[][] matrix)
        {
            bool[][] seen = new bool[matrix.Length][];
            for (var i = 0; i < matrix.Length; i++)
            {
                seen[i] = new bool[matrix[i].Length];
            }
            Queue<int[]> queue = GetZerosCoordinates(matrix, seen);

            while (queue.Count > 0)
            {
                var currentCoordinates = queue.Dequeue();
                var currentRow = currentCoordinates[0];
                var currentCol = currentCoordinates[1];
                for (int j = 0; j < matrix[currentRow].Length; j++)
                {
                    matrix[currentRow][j] = 0;
                }

                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][currentCol] = 0;
                }
            };

            Print2DArray(matrix);
        }

        private static Queue<int[]> GetZerosCoordinates(int[][] matrix, bool[][] seen)
        {
            Queue<int[]> queue = new Queue<int[]>();
            Queue<int[]> zerosqueue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            seen[0][0] = true;
            while (queue.Count > 0)
            {
                var currentCoordinates = queue.Dequeue();
                var currentRow = currentCoordinates[0];
                var currentCol = currentCoordinates[1];
                if (matrix[currentRow][currentCol] == 0) zerosqueue.Enqueue(new int[] { currentRow, currentCol });
                seen[currentRow][currentCol] = true;

                for (int k = 0; k < directions.Length; k++)
                {

                    var direction = directions[k];
                    var nextRow = currentRow + direction[0];
                    var nextCol = currentCol + direction[1];
                    if (nextRow < 0 || nextRow >= matrix.Length || nextCol < 0 || nextCol >= matrix[0].Length)
                        continue;

                    if (seen[nextRow][nextCol] != true) queue.Enqueue(new int[] { nextRow, nextCol });

                }

            }

            return zerosqueue;
        }

        public static void Print2DArray(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }


        public static void SetZerosHorizontally(int[][] matrix, int i)
        {
            for (int j = 0; j < matrix.Length; j++)
            {
                matrix[i][j] = 0;
            }
        }

        public static int IslandPerimeter(int[][] grid)
        {
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) queue.Enqueue(new int[] { i, j });
                }
            }

            int perimeter = 0;
            while (queue.Count > 0)
            {
                var currentCoordinates = queue.Dequeue();
                int numberOfWalls = 0;
                for (int k = 0; k < directions.Length; k++)
                {

                    var currentRow = currentCoordinates[0];
                    var currentCol = currentCoordinates[1];
                    var direction = directions[k];
                    var nextRow = currentRow + direction[0];
                    var nextCol = currentCol + direction[1];
                    if (nextRow < 0 || nextRow >= grid.Length || nextCol < 0 || nextCol >= grid[0].Length)
                    {
                        numberOfWalls++;
                        continue;
                    }
                    if (grid[nextRow][nextCol] == 0)
                        numberOfWalls++;

                }
                perimeter += numberOfWalls;
            }

            return perimeter;
        }

        public static int MaxAreaOfIsland(int[][] grid)
        {
            Queue<int[]> queue = new Queue<int[]>();
            int maxArea = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int currentArea = 1;
                        grid[i][j] = 0;
                        queue.Enqueue(new int[] { i, j });
                        while (queue.Count != 0)
                        {
                            var currentCoordinates = queue.Dequeue();
                            for (int k = 0; k < directions.Length; k++)
                            {

                                var currentRow = currentCoordinates[0];
                                var currentCol = currentCoordinates[1];
                                var direction = directions[k];
                                var nextRow = currentRow + direction[0];
                                var nextCol = currentCol + direction[1];
                                if (nextRow < 0 || nextRow >= grid.Length || nextCol < 0 || nextCol >= grid[0].Length)
                                    continue;

                                if (grid[nextRow][nextCol] == 1)
                                {
                                    currentArea++;
                                    grid[nextRow][nextCol] = 0;
                                    queue.Enqueue(new int[] { nextRow, nextCol });
                                }
                            }
                        }

                        if (currentArea > maxArea) maxArea = currentArea;
                    }
                }
            }
            return maxArea;
        }

        public static int NumIslands(char[][] grid)
        {
            Queue<int[]> queue = new Queue<int[]>();
            int numberOfIslands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numberOfIslands += 1;
                        grid[i][j] = '0';
                        queue.Enqueue(new int[] { i, j });
                        while (queue.Count != 0)
                        {
                            var currentCoordinates = queue.Dequeue();
                            for (int k = 0; k < directions.Length; k++)
                            {

                                var currentRow = currentCoordinates[0];
                                var currentCol = currentCoordinates[1];
                                var direction = directions[k];
                                var nextRow = currentRow + direction[0];
                                var nextCol = currentCol + direction[1];
                                if (nextRow < 0 || nextRow >= grid.Length || nextCol < 0 || nextCol >= grid[0].Length)
                                    continue;

                                if (grid[nextRow][nextCol] == '1')
                                {
                                    grid[nextRow][nextCol] = '0';
                                    queue.Enqueue(new int[] { nextRow, nextCol });
                                }
                            }
                        }
                    }
                }
            }
            return numberOfIslands;
        }
    }
}