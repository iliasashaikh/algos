using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    [TestFixture]
    public class SearchRotatedPramp
    {
        public int Search(int[] shiftArr, int num)
        {

            if (shiftArr == null || shiftArr.Length == 0)
                return -1;

            int rotationPoint = FindRotationPoint(shiftArr);

            int lo = 0;
            int hi = shiftArr.Length - 1;

            if (rotationPoint == 0)
            {
                hi = shiftArr.Length - 1;
            }
            else
            if (num >= shiftArr[0])
            {
                hi = rotationPoint - 1;
            }
            else
                lo = rotationPoint;


            var r = BinarySearch(shiftArr, lo, hi, num);
            return r;
        }

        static int BinarySearch(int[] arr, int lo, int hi, int target)
        {
            while (lo <= hi)
            {
                var mid = (lo + hi) / 2;

                if (arr[mid] == target)
                    return mid;

                if (target > arr[mid])
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }

            return -1;

        }

        static int FindRotationPoint(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            if (arr[0] <= arr[arr.Length - 1])
                return 0;

            while (lo <= hi)
            {
                var mid = (lo + hi) / 2;

                if (arr[mid - 1] > arr[mid])
                    return mid;

                if (arr[mid] > arr[0])
                {
                    lo = mid + 1;
                }
                else
                    hi = mid - 1;
            }

            return 0;
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

        [Test]
        public void Test8()
        {
            var r = Search(new int[] { 9, 12, 17, 2, 4, 5, 6 }, 4);
            Assert.AreEqual(4, r);
        }

        [Test]
        public void Test9()
        {
            var r = Search(new int[] { 1, 2, 3, 4, 5, 0 }, 0);
            Assert.AreEqual(5, r);
        }

    }
}
