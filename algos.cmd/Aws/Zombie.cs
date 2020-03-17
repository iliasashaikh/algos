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
        }

        public static void Test()
        {
            Run(new int[][] { new int[] {1} });
        }
    }
}
