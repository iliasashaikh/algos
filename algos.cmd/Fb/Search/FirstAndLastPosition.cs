/*
 Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

Follow up: Could you write an algorithm with O(log n) runtime complexity?

 

Example 1:

Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]
Example 2:

Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]
Example 3:

Input: nums = [], target = 0
Output: [-1,-1]
 

Constraints:

0 <= nums.length <= 105
-109 <= nums[i] <= 109
nums is a non-decreasing array.
-109 <= target <= 109
  */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Fb.Search
{
    [TestFixture]
    public class FirstAndLastPosition
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
                return new int[2] { -1, -1 };

            var lo = FindLow(nums,target);
            var hi = FindHigh(nums,target);

            return new int[2] {lo,hi};
        }
        
        // [1] , 1
        // 
        private int FindLow(int[] nums, int target)
        {
            //[5,7,7,8,8,10], target = 8
            var len = nums.Length;
            var lo = 0;
            var hi = len - 1;
            int mid = -1;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (nums[mid] == target && (mid == 0 || mid > 0 && nums[mid - 1] < target))
                    return mid;
                else
                if (target > nums[mid])
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }

            if (nums[mid] == target)
                return mid;

            return -1;
        }

        private int FindHigh(int[] nums, int target)
        {
            //[0,1,2,3,4,5]
            //[5,7,7,8,8,10], target = 8
            // l = 0, h = 5, m = 2 : 7
            // l = 3, h = 5, m = 4 : 8 
            // l = 5, h = 5, m = 5 : 8
            var len = nums.Length;
            var lo = 0;
            var hi = len - 1;
            int mid = -1;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (nums[mid] == target && (mid == len - 1 || mid < len && nums[mid + 1] > target))
                    return mid;
                else
                if (target >= nums[mid])
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }

            if (nums[mid] == target)
                return mid;

            return -1;
        }

        [Test]
        public void Test1()
        {
            var r = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            Assert.AreEqual(
                new int[] { 3, 4 }, r);
        }

        [Test]
        public void Test2()
        {
            var r = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            Assert.AreEqual(
                new int[] { -1, -1 }, r);
        }

        [Test]
        public void Test3()
        {
            var r = SearchRange(new int[] { }, 6);
            Assert.AreEqual(
                new int[] { -1, -1 }, r);
        }
    }
}
