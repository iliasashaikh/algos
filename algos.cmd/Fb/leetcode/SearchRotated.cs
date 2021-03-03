using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    [TestFixture]
    public class SearchRotated
    {
        public int Search(int[] nums, int target)
        {

            int lo, hi = 0;
            int md = -1;
            if (target == nums[0])
                return 0;

            var rotationPoint = GetRotationPoint(nums);
            Console.WriteLine($"rotationPoint={rotationPoint}");

            if (target > nums[0])
            {
                lo = 0;
                hi = rotationPoint;
            }
            else
            {
                lo = rotationPoint;
                hi = nums.Length - 1;
            }


            while (lo < hi)
            {
                md = (lo + hi) / 2;

                if (target == nums[md])
                    return md;

                if (target > nums[md])
                {
                    lo = md;
                }
                else
                    hi = md;

            }

            return -1;
        }

        int GetRotationPoint(int[] nums)
        {
            var lo = 0;
            var hi = nums.Length -1 ;
            var mid = 0;

            while (lo < hi)
            {
                mid = (lo + hi) / 2;

                if (nums[mid] > nums[0])
                    lo = mid;
                else
                    hi = mid;

                if (lo + 1 == hi)
                    return hi;

            }

            return 0;

        }

        [Test]
        public void Test()
        {
            var r = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3);
            Assert.AreEqual(-1, r);
        }
    }
}
