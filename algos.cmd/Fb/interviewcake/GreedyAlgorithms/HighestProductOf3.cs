/*
 Given an array of integers, find the highest product you can get from three of the integers.
 The input arrayOfInts will always have at least three integer
*/
using System;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class HighestProductOf3
    {

        public int GetHighestProductOf3(int[] arrayOfInts)
        {
            // Calculate the highest product of three numbers


            return 0;
        }
        // Tests

        [Test]
        public void ShortArrayTest()
        {
            var actual = GetHighestProductOf3(new int[] { 1, 2, 3, 4 });
            var expected = 24;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LongerArrayTest()
        {
            var actual = GetHighestProductOf3(new int[] { 6, 1, 3, 5, 7, 8, 2 });
            var expected = 336;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayHasOneNegativeTest()
        {
            var actual = GetHighestProductOf3(new int[] { -5, 4, 8, 2, 3 });
            var expected = 96;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayHasTwoNegativesTest()
        {
            var actual = GetHighestProductOf3(new int[] { -10, 1, 3, 2, -10 });
            var expected = 300;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayHasAllNegativesTest()
        {
            var actual = GetHighestProductOf3(new int[] { -5, -1, -3, -2 });
            var expected = -6;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExceptionWithEmptyArrayTest()
        {
            Assert.Throws<ArgumentException>(() => GetHighestProductOf3(new int[] { }));
        }

        [Test]
        public void ExceptionWithOneNumberTest()
        {
            Assert.Throws<ArgumentException>(() => GetHighestProductOf3(new int[] { 1 }));
        }

        [Test]
        public void ExceptionWithTwoNumbersTest()
        {
            Assert.Throws<ArgumentException>(() => GetHighestProductOf3(new int[] { 1, 1 }));
        }
    }
}