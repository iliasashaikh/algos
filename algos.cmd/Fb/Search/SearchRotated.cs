using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.Search
{
    [TestFixture]
    public class SearchRotated
    {
        public int Search(int[] nums, int target)
        {

            if (nums.Length <= 0)
                return -1;

            int lo = 0;
            int hi = nums.Length - 1;

            var rotationPoint = GetRotationPoint(nums);

            if (target >= nums[0])
                hi = rotationPoint - 1;
            else
                lo = rotationPoint;


            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] == target)
                    return mid;

                if (target >= nums[mid])
                {
                    lo = mid + 1;
                }
                else
                    hi = mid - 1;
            }

            return -1;

            Console.WriteLine($"rotationPoint={rotationPoint}");


        }

        int GetRotationPoint(int[] nums)
        {
            var lo = 0;
            var hi = nums.Length - 1;


            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;

                var midValue = nums[mid];
                if (midValue >= nums[0])
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }

                if (lo + 1 == hi)
                    break;

            }
            return hi;
        }

        [Test]
        public void Test1()
        {
            var r = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 2);
            Assert.AreEqual(6, r);
        }

        [Test]
        public void Test2()
        {

            var r = Search(new int[] { }, 4);
            Assert.AreEqual(-1, r);
        }

        [Test]
        public void Test3()
        {
            var r = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4);
            Assert.AreEqual(0, r);
        }
        [Test]
        public void Test4()
        {
            var r = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            Assert.AreEqual(4, r);
        }

        [Test]
        public void Test5()
        {
            var r = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5);
            Assert.AreEqual(1, r);
        }

        [Test]
        public void Test6()
        {
            var r = Search(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 5);
            Assert.AreEqual(5, r);
        }

        [Test]
        public void Test7()
        {
            var r = Search(new int[] { 0 }, 0);
            Assert.AreEqual(0, r);
        }
    }
}
