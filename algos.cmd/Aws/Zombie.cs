using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
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
            var hours = GetHoursBruteForce(grid);
            $"Total hours brute force= {hours}".Dump2();

            var hours2 = GetHoursBfs(grid);
            $"Total hours bfs= {hours2}".Dump2();
        }

        private static int GetHoursBfs(int[][] grid)
        {
            Queue<(int row, int col)> zombieQ = new Queue<(int row, int col)>();
            int hours = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            //1. add all the zombies 
            //2. while zombie q is not empty
            //3.    convert surrounding to zombie
            //4.    add converted to q
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                        zombieQ.Enqueue((i,j));
                }

            while (zombieQ.Count > 0)
            {
                var anyZombifications = false;
                var numZombies = zombieQ.Count; // make a copy of the count
                for (int i = 0; i < numZombies; i++)
                {
                    var z = zombieQ.Dequeue();
                    anyZombifications = ZombifyHuman(ref grid, ref zombieQ, z.row, z.col, rows, cols);
                    grid.Dump2();
                }

                if (anyZombifications)
                    hours++;
            }

            return hours;
        }

        private static bool ZombifyHuman(ref int[][] grid, ref Queue<(int row, int col)> zombieQ, in int row, in int col, in int rows, in int cols)
        {
            //if (row > 0)
            //    grid[row - 1][col] = 1;
            //if (row < rows - 1)
            //    grid[row + 1][col] = 1;

            //if (col > 0)
            //    grid[col - 1][row] = 1;
            //if (col < cols - 1)
            //    grid[col + 1][row] = 1;
            bool zombified = false;
            if (row > 0 && grid[row - 1][col] == 0)
            {
                grid[row - 1][col] = 1;
                zombieQ.Enqueue((row - 1,col));
                zombified = true;
            }

            if (row < rows - 1 && grid[row + 1][col] == 0)
            {
                grid[row + 1][col] = 1;
                zombieQ.Enqueue((row + 1,col));
                zombified = true;
            }

            if (col > 0 && grid[row][col - 1] == 0)
            {
                grid[row][col - 1] = 1;
                zombieQ.Enqueue((row, col - 1));
                zombified = true;
            }

            if (col < cols - 1 && grid[row][col + 1] == 0)
            {
                grid[row][col + 1] = 1;
                zombieQ.Enqueue((row, col + 1));
                zombified = true;
            }

            return zombified;
        }


        private static int GetHoursBruteForce(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int hours = 0;

            while (AnyHumans(grid))
            {
                Zombify(grid, rows, cols);
                hours++;
            }

            return hours;
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
                new int[]{ 0, 0, 0, 0, 1},
                new int[]{ 0, 0, 0, 0, 0},
                new int[]{ 0, 0, 0, 0, 0},
                new int[]{ 1, 0, 0, 0, 0},
            };

            Run(grid);
        }
    }
}
