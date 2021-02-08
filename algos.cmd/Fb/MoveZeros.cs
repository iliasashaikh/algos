﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos
{
    /*
     * Move Zeroes

Solution
Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Example:

Input: [0,1,0,3,12]
Output: [1,3,12,0,0]
Note:

You must do this in-place without making a copy of the array.
Minimize the total number of operations.
     */
    public static class MoveZeros
    {

        public static string Stringify<T>(IEnumerable<T> e) => $"[{(string.Join(',', e.Select(n => n.ToString()).ToArray()))}]";

        public static void Run()
        {
            Do(new int[] { 0, 1, 0, 3, 12 });
            Do(new int[]{ 0, 0, 1});
        }

        public static int[] Do(int[] nums)
        {
            Console.WriteLine(Stringify(nums));

            int insertIndex = 0;

            for (int i = 0; i < nums?.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[insertIndex], nums[i]) = (nums[i], nums[insertIndex]);
                    insertIndex++;
                }
            }

            Console.WriteLine(Stringify(nums));

            return nums;
        }
    }
}
