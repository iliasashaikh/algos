using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.StringsArrays
{
    [TestFixture]
    public class CalculateRoot
    {
        public double Root2(double x, int n)
        {
            double left = 0;
            double right = x;

            while (left < right)
            {
                double root = left + (right - left) / 2;
                var calcPow = Pow(root, n);
                
                double diff = (calcPow - x);
                diff = diff < 0?-diff:diff;

                if (diff <= 0.001)
                    return root;

                if (calcPow > x)
                    right = root;
                else
                    left = root + 0.001;
            }

            return left;
        }


        public static double Root(double x, int n)
        {
            double left = 0.0, right = x;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                double temp = 1.0;
                for (int i = 0; i < n; i++)
                {
                    temp *= mid;
                }
                if (temp < x)
                {
                    left = mid + 0.001;
                }
                else
                {
                    right = mid;
                }
            }

            return right;
        }

        public static double Pow(double root, double n)
        {
            double r = 1;
            for (int i = 0; i < n; i++)
            {
                r *= root;
            }
            return r;
        }

        [Test]
        public void Test()
        {
            var r = Root(3, 2);
            var r2 = Root2(4, 2);
            Assert.AreEqual(2, r2, 0.001);
        }
    }
}
