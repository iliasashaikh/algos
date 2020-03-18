using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleDump;

namespace algos.Aws
{
    /*
     Given a 2D grid, each cell is either a zombie 1 or a human 0. 
     Zombies can turn adjacent (up/down/left/right) human beings into zombies every hour. 
     Find out how many hours does it take to infect all humans?
    https://leetcode.com/discuss/interview-question/411357/
    */
    public static class Zombie
    {
        public static void Run(int[][] grid)
        {
            grid.Dump2();
            int rows = grid.Length;
            int cols = grid[0].Length;
            int hours = 0;
            
            while (AnyHumans(grid))
            {
                Zombify(grid, rows, cols);
                hours++;
            }

            Console.WriteLine(hours);
        }

        private static void Zombify(int[][] grid, int rows, int cols)
        {
            Queue<(int row, int col)> zombieQ = new Queue<(int row, int col)>();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (i > 0)
                            zombieQ.Enqueue((i - 1, j));

                        if (i < rows - 1)
                            zombieQ.Enqueue((i + 1, j));

                        if (j > 0)
                            zombieQ.Enqueue((i, j - 1));

                        if (j < cols - 1)
                            zombieQ.Enqueue((i, j + 1));
                    }
                }
            
            while (zombieQ.TryDequeue(out var z))
            {
                grid[z.row][z.col] = 1;
            }

            grid.Dump2();
        }

        static bool AnyHumans(int[][] grid)
        {
            if (grid == null)
                return true;

            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 0)
                        return true;
                }

            return false;
        }

        public static void Test()
        {
            var grid = new int[4][]
            {
                new int[]{ 0, 1, 1, 0, 1},
                new int[]{ 0, 1, 0, 1, 0},
                new int[]{ 0, 0, 0, 0, 1},
                new int[]{ 0, 1, 0, 0, 0},
            };

            Run(grid);
        }
    }
}
