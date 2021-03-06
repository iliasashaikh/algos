/*
 You have an array of integers, and for each index you want to find the product of every integer except the integer at that index.

Write a method GetProductsOfAllIntsExceptAtIndex() that takes an array of integers and returns an array of the products.

For example, given:

  [1, 7, 3, 4]

your method would return:

  [84, 12, 28, 21]

by calculating:

  [7 * 3 * 4,  1 * 3 * 4,  1 * 7 * 4,  1 * 7 * 3]

Here's the catch: You can't use division in your solution! 
*/
using System;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class ProductOfInts
    {
        public int[] GetProductsOfAllIntsExceptAtIndex(int[] intArray)
        {

            if (intArray == null || intArray.Length <= 1)
                throw new ArgumentException();

            void Dump(int[] a) => Console.WriteLine($"[{string.Join(",", a)}]");
            // make 2 arrays, left & right 
            int[] left = new int[intArray.Length];
            int[] right = new int[intArray.Length];

            Array.Fill<int>(left, 1);
            Array.Fill<int>(right, 1);
            Dump(intArray);

            for (int i = 1, j = intArray.Length - 2; i < intArray.Length; i++, j--)
            {
                left[i] = left[i - 1] * intArray[i - 1];
                right[j] = right[j + 1] * intArray[j + 1];
                Dump(left);
                Dump(right);
            }

            var r = new int[intArray.Length];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = left[i] * right[i];
            }

            return r;
        }

        // Tests

        [Test]
        public void SmallArrayInputTest()
        {
            var expected = new int[] { 6, 3, 2 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 1, 2, 3 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LongArrayInputTest()
        {
            var expected = new int[] { 120, 480, 240, 320, 960, 192 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 8, 2, 4, 3, 1, 5 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InputHasOneZeroTest()
        {
            var expected = new int[] { 0, 0, 36, 0 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 6, 2, 0, 3 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InputHasTwoZerosTest()
        {
            var expected = new int[] { 0, 0, 0, 0, 0 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 4, 0, 9, 1, 0 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InputHasOneNegativeNumberTest()
        {
            var expected = new int[] { 32, -12, -24 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { -3, 8, 4 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllNegativesInputTest()
        {
            var expected = new int[] { -8, -56, -14, -28 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { -7, -1, -4, -2 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExceptionWithEmptyInputTest()
        {
            Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex(new int[] { }));
        }

        [Test]
        public void ExceptionWithOneNumberInputTest()
        {
            Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex(new int[] { 1 }));
        }

    }
}