/*
 Given an array of integers, find the highest product you can get from three of the integers.
 The input arrayOfInts will always have at least three integer
*/
using System;
using NUnit.Framework;
using static System.Math;
using static System.Console;
namespace algos.Fb
{
    [TestFixture]
    public class HighestProductOf3
    {
        public int GetHighestProductOf3(int[] arrayOfInts)
        {
            if (arrayOfInts.Length <=2)
                throw new ArgumentException();
            
            if (arrayOfInts.Length == 3)
                return arrayOfInts[0]*arrayOfInts[1]*arrayOfInts[2];

            Array.Sort(arrayOfInts);

            return Max(
                arrayOfInts[0]*arrayOfInts[1]*arrayOfInts[arrayOfInts.Length-1],
                arrayOfInts[arrayOfInts.Length-1]*arrayOfInts[arrayOfInts.Length-2]*arrayOfInts[arrayOfInts.Length-3]
                );
        }
        public int GetHighestProductOf3_OneLoop(int[] arrayOfInts)
        {

            if (arrayOfInts.Length <=2)
                throw new ArgumentException();
            
            if (arrayOfInts.Length == 3)
                return arrayOfInts[0]*arrayOfInts[1]*arrayOfInts[2];

            (int,int) Min2(int a, int b, int c) => (Min(a,b), Min(Max(a,b),c));
            (int,int,int) Max3(int a, int b, int c, int d) => (
                Max(a,b), 
                Max(Min(a,b),c),
                Max(Min(Min(a,b),c),d)
            );
            
            int min1 = arrayOfInts[0];
            int min2 = arrayOfInts[1];
            int max1 = arrayOfInts[0];
            int max2 = arrayOfInts[1];
            int max3 = arrayOfInts[2];

            int max = int.MinValue;

            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                var current = arrayOfInts[i];
                (min1,min2) = Min2(min1,min2,current);
                if (i > 2)
                    (max1,max2,max3) = Max3(max1,max2,max3,current);
                
                WriteLine($"max:{max1},{max2},{max3}    min:{min1},{min2}");
            }
            max = Max(Max(max1,max2),max3);

            var maxProduct = Max(min1*min2*max, max1*max2*max3);

            return maxProduct;
        }
        public int GetHighestProductOf3_Twoloops(int[] arrayOfInts)
        {

            if (arrayOfInts.Length <=2)
                throw new ArgumentException();

            (int,int) Min2(int a, int b, int c) => (Min(a,b), Min(Max(a,b),c));
            (int,int) Max2(int a, int b, int c) => (Max(a,b), Max(Min(a,b),c));

            //find the max & its index
            //find the 2 mins and next 2 maxs
            int maxValue = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < arrayOfInts.Length; i++)
            {
                if (arrayOfInts[i] > maxValue)
                {
                    maxValue = arrayOfInts[i];
                    maxIndex = i;
                }
            }

            // Calculate the highest product of three numbers
            int min1 = int.MaxValue;
            int min2 = int.MaxValue;
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < arrayOfInts.Length; i++)
            {
                if (i == maxIndex)
                    continue;

                var current = arrayOfInts[i];
                (min1,min2) = Min2(min1,min2,current);
                (max1,max2) = Max2(max1,max2,current);

            }
            
            var maxProduct = Max(min1*min2*maxValue,max1*max2*maxValue);

            return maxProduct;
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