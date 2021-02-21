using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
/*
 * 
In order to win the prize for most cookies sold, my friend Alice and I are going to merge our Girl Scout Cookies orders and enter as one unit.

Each order is represented by an "order id" (an integer).

We have our lists of orders sorted numerically already, in arrays.Write a method to merge our arrays of orders into one sorted array.

For example:

  int[] myArray = { 3, 4, 6, 10, 11, 15 };
    int[] alicesArray = { 1, 5, 8, 12, 14, 19 };

    // Prints [1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19]
    Console.WriteLine($"[{string.Join(", ", Merge(myArray, alicesArray))}]");
*/

    [TestFixture]
    public class MergeSortedArrays
    {
        
        /// <summary>
        /// Time cost : O(n) + O(nLogN)
        /// Space cost : O(n)
        /// </summary>
        /// <param name="myArray"></param>
        /// <param name="alicesArray"></param>
        /// <returns></returns>
        public int[] BruteForce(int[] myArray, int[] alicesArray)
        {
            var mergedArray = new int[myArray.Length + alicesArray.Length];
            myArray.CopyTo(mergedArray, 0);
            alicesArray.CopyTo(mergedArray, myArray.Length);
            Array.Sort(mergedArray);

            return mergedArray;
        }

        public int[] Merge(int[] myArray, int[] alicesArray)
        {
            int left = 0;
            int right = 0;

            if (myArray == null || myArray.Length == 0) return alicesArray;
            if (alicesArray == null || alicesArray.Length == 0) return myArray;

            var mergedArray = new int[myArray.Length + alicesArray.Length];

            for (int i = 0; i < mergedArray.Length; i++)
            {

                if (right == alicesArray.Length)
                    mergedArray[i] = myArray[left++];
                else
                if (left == myArray.Length)
                    mergedArray[i] = alicesArray[right];
                else
                if (myArray[left] < alicesArray[right])
                {
                    mergedArray[i] = myArray[left];
                    left++;
                }
                else
                {
                    mergedArray[i] = alicesArray[right];
                    right++;
                }
            }
            return mergedArray;
        }

        [Test]
        public void BothArraysAreEmptyTest()
        {
            var myArray = new int[] { };
            var alicesArray = new int[] { };
            var expected = new int[] { };
            var actual = Merge(myArray, alicesArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstArrayIsEmptyTest()
        {
            var myArray = new int[] { };
            var alicesArray = new int[] { 1, 2, 3 };
            var expected = new int[] { 1, 2, 3 };
            var actual = Merge(myArray, alicesArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SecondArrayIsEmptyTest()
        {
            var myArray = new int[] { 5, 6, 7 };
            var alicesArray = new int[] { };
            var expected = new int[] { 5, 6, 7 };
            var actual = Merge(myArray, alicesArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BothArraysHaveSomeNumbersTest()
        {
            var myArray = new int[] { 2, 4, 6 };
            var alicesArray = new int[] { 1, 3, 7 };
            var expected = new int[] { 1, 2, 3, 4, 6, 7 };
            var actual = Merge(myArray, alicesArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArraysAreDifferentLengthsTest()
        {
            var myArray = new int[] { 2, 4, 6, 8 };
            var alicesArray = new int[] { 1, 7 };
            var expected = new int[] { 1, 2, 4, 6, 7, 8 };
            var actual = Merge(myArray, alicesArray);
            Assert.AreEqual(expected, actual);
        }
    }
}
