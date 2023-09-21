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

        private static bool[] result;

        public static IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            Print2DArray(heights);
            int rows = heights.Length;
            int cols = heights[0].Length;
            bool[,] pacVisit = new bool[rows, cols];
            bool[,] atVisit = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                DFSPacificAndAtlantic(i, 0, heights, pacVisit, heights[i][0]);
                DFSPacificAndAtlantic(i, cols - 1, heights, atVisit, heights[i][cols - 1]);
            }

            for (int j = 0; j < cols; j++)
            {
                DFSPacificAndAtlantic(0, j, heights, pacVisit, heights[0][j]);
                DFSPacificAndAtlantic(rows - 1, j, heights, atVisit, heights[rows - 1][j]);
            }

            List<IList<int>> result = new();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (pacVisit[i, j] && atVisit[i, j])
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }

            return result;
        }

        public static void DFSPacificAndAtlantic(int r, int c, int[][] heights, bool[,] visit, int prevHeight)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            if (r < 0 || r >= rows || c < 0 || c >= cols || heights[r][c] < prevHeight || visit[r, c])
                return;

            visit[r, c] = true;
            DFSPacificAndAtlantic(r + 1, c, heights, visit, heights[r][c]);
            DFSPacificAndAtlantic(r - 1, c, heights, visit, heights[r][c]);
            DFSPacificAndAtlantic(r, c + 1, heights, visit, heights[r][c]);
            DFSPacificAndAtlantic(r, c - 1, heights, visit, heights[r][c]);
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            bool[][] seen = new bool[image.Length][];
            for (var i = 0; i < image.Length; i++)
            {
                seen[i] = new bool[image[i].Length];
            }

            Queue<int[]> queue = new Queue<int[]>();
            int m = image.Length, n = image[0].Length;
            int startingColor = image[sr][sc];
            queue.Enqueue(new int[] { sr, sc });
            while (queue.Count > 0)
            {
                var coordinates = queue.Dequeue();
                int currentRow = coordinates[0], currentColumn = coordinates[1];
                seen[currentRow][currentColumn] = true;
                image[currentRow][currentColumn] = color;
                for (int i = 0; i < directions.Length; i++)
                {
                    var currentDirection = directions[i];
                    var nextRow = currentRow + currentDirection[0];
                    var nextCol = currentColumn + currentDirection[1];
                    if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n || seen[nextRow][nextCol] == true) continue;
                    if (image[nextRow][nextCol] == startingColor) queue.Enqueue(new int[] { nextRow, nextCol });
                }
            }
            Print2DArray(image);
            return image;
        }

        public static bool Exist(char[][] board, string word)
        {
            var queue = FindCharacter(word[0], board);
            if (queue.Count == 0) return false;
            while (queue.Count > 0)
            {
                bool[][] seen = new bool[board.Length][];
                for (var i = 0; i < board.Length; i++)
                {
                    seen[i] = new bool[board[i].Length];
                }

                var coordinates = queue.Dequeue();
                int currentRow = coordinates[0], currentColumn = coordinates[1];
                result = new bool[word.Length];
                int currentWordIndex = 0;
                ExistDFS(board, seen, result, currentRow, currentColumn, currentWordIndex, word);

                if (CheckResult(result)) return true;
            }

            return false;
        }

        private static bool CheckResult(bool[] result)
        {
            for (int k = 0; k < result.Length; k++)
            {
                if (result[k] == false) return false;
            }
            return true;
        }

        public static void ExistDFS(char[][] board, bool[][] seen, bool[] result, int r, int c, int currentWordIndex, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;
            if (r < 0 || r >= rows || c < 0 || c >= cols || seen[r][c] || currentWordIndex >= word.Length)
                return;
            seen[r][c] = true;
            if (board[r][c] == word[currentWordIndex])
            {
                result[currentWordIndex] = true;
                ExistDFS(board, seen, result, r + 1, c, currentWordIndex + 1, word);
                ExistDFS(board, seen, result, r - 1, c, currentWordIndex + 1, word);
                ExistDFS(board, seen, result, r, c + 1, currentWordIndex + 1, word);
                ExistDFS(board, seen, result, r, c - 1, currentWordIndex + 1, word);
            }
        }

        static Queue<int[]> FindNextCharacters(char cc, char[][] matrix, int currentRow, int currentColumn, bool[][] seen)
        {
            Queue<int[]> queue = new Queue<int[]>();
            int m = matrix.Length, n = matrix[0].Length;
            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];
                var nextRow = currentRow + currentDirection[0];
                var nextCol = currentColumn + currentDirection[1];
                if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n || seen[nextRow][nextCol] == true) continue;
                if (matrix[nextRow][nextCol] == cc) queue.Enqueue(new int[] { nextRow, nextCol });
            }

            return queue;
        }

        static Queue<int[]> FindCharacter(char cc, char[][] matrix)
        {
            Queue<int[]> queue = new Queue<int[]>();
            Queue<int[]> coordinates = new Queue<int[]>();

            bool[][] seen = new bool[matrix.Length][];
            for (var i = 0; i < matrix.Length; i++)
            {
                seen[i] = new bool[matrix[i].Length];
            }

            queue.Enqueue(new int[] { 0, 0 });

            while (queue.Count > 0)
            {
                var currentCoordinates = queue.Dequeue();
                int currentRow = currentCoordinates[0];
                int currentCol = currentCoordinates[1];
                seen[currentRow][currentCol] = true;
                if (matrix[currentRow][currentCol] == cc) coordinates.Enqueue(new int[] { currentRow, currentCol });
                for (int i = 0; i < directions.Length; i++)
                {
                    var currentDirection = directions[i];
                    var nextRow = currentRow + currentDirection[0];
                    var nextCol = currentCol + currentDirection[1];
                    if (nextRow < 0 || nextRow >= matrix.Length || nextCol < 0 || nextCol >= matrix[currentRow].Length || seen[nextRow][nextCol] == true) continue;
                    queue.Enqueue(new int[] { nextRow, nextCol });
                    currentRow = nextRow;
                    currentCol = nextCol;
                    seen[currentRow][currentCol] = true;
                }
            }

            return coordinates;
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
                if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n || matrix[nextRow][nextCol] == 1000)
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