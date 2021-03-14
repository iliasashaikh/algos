using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algos.Fb.StringsArrays
{
    //Example 1:

    //Input: nums = [1,2,3]
    //Output: [1,3,2]
    //Example 2:

    //Input: nums = [3,2,1]
    //Output: [1,2,3]
    //Example 3:

    //Input: nums = [1,1,5]
    //Output: [1,5,1]
    //Example 4:

    //Input: nums = [1]
    //Output: [1]

    [TestFixture]
    public class NextPermutation
    {
        public void GetNextPermutation(int[] nums)
        {
            // find if there is a next permutation
            var len = nums.Length;

            if (len <= 1)
                return;

            int i = len - 2;
            int pivotIdx = -1;
            while (i >= 0)
            {
                if (nums[i] < nums[i + 1])
                {
                    pivotIdx = i;
                    break;
                }
                i--;
            }
            if (pivotIdx == -1)
            {
                Array.Reverse(nums);
                return;
            }

            //find closest to pivot and greater
            int minDiff = int.MaxValue;
            int swapIdx = -1;
            int pivot = nums[pivotIdx];

            for (int j = pivotIdx + 1; j < len; j++)
            {
                if (nums[j] > pivot)
                {
                    int diff = nums[j] - pivot;
                    if (diff <= minDiff)
                    {
                        minDiff = diff;
                        swapIdx = j;
                    }
                }
            }

            //swap swapIdx <> pivotIdx
            (nums[swapIdx], nums[pivotIdx]) = ((nums[pivotIdx], nums[swapIdx]));

            // reverse from pivotIdx + 1 onwards
            int left = pivotIdx + 1;
            int right = len - 1;

            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }

        }


        [Test]
        public void Test()
        {
            var actual = new int[] { 2, 3, 1, 3, 3 };
            GetNextPermutation(actual);
            Assert.AreEqual(new int[] { 2, 3, 3, 1, 3 }, actual);
        }
    }
}
