namespace ConsoleApp1
{
    internal static class Arrays2D
    {
        private static int[][] directions = new int[][] {
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1}};
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