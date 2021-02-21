using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    /*
     
            My cake shop is so popular, I'm adding some tables and hiring wait staff so folks can have a cute sit-down cake-eating experience.

            I have two registers: one for take-out orders, and the other for the other folks eating inside the cafe. All the customer orders get combined into one list for the kitchen, where they should be handled first-come, first-served.

            Recently, some customers have been complaining that people who placed orders after them are getting their food first. Yikes—that's not good for business!

            To investigate their claims, one afternoon I sat behind the registers with my laptop and recorded:

            The take-out orders as they were entered into the system and given to the kitchen. (takeOutOrders)
            The dine-in orders as they were entered into the system and given to the kitchen. (dineInOrders)
            Each customer order (from either register) as it was finished by the kitchen. (servedOrders)
            Given all three arrays, write a method to check that my service is first-come, first-served. All food should come out in the same order customers requested it.

            We'll represent each customer order as a unique integer.

            As an example,

                Take Out Orders: [1, 3, 5]
                Dine In Orders: [2, 4, 6]
                Served Orders: [1, 2, 4, 6, 5, 3]
            would not be first-come, first-served, since order 3 was requested before order 5 but order 5 was served first.

            But,

                Take Out Orders: [17, 8, 24]
                Dine In Orders: [12, 19, 2]
                Served Orders: [17, 8, 12, 19, 24, 2]
            would be first-come, first-served.

            Note: Order numbers are arbitrary. They do not have to be in increasing order.     
     
     */
    [TestFixture]
    public class CafeOrderChecker
    {
        //Time complexity = O(n2)
        //Space complexity = O(n2)
        public bool IsFirstComeFirstServedRecursive(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {
            // Check if we're serving orders first-come, first-served

            if (servedOrders.Length == 0 && takeOutOrders.Length == 0 && dineInOrders.Length == 0)
                return true;

            if (dineInOrders.Length > 0 && servedOrders.Length > 0 && servedOrders[0] == dineInOrders[0])
                return IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders[1..], servedOrders[1..]);
            else
            if (takeOutOrders.Length > 0 && servedOrders.Length > 0 && servedOrders[0] == takeOutOrders[0])
                return IsFirstComeFirstServedRecursive(takeOutOrders[1..], dineInOrders, servedOrders[1..]);

            return false;
        }

        public bool IsFirstComeFirstServedRecursiveSpan(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {

            bool IsFirstComeFirstServed(Span<int> takeOutOrders, Span<int> dineInOrders, Span<int> servedOrders)
            {
                if (servedOrders.Length == 0 && takeOutOrders.Length == 0 && dineInOrders.Length == 0)
                    return true;

                if (dineInOrders.Length > 0 && servedOrders.Length > 0 && servedOrders[0] == dineInOrders[0])
                    return IsFirstComeFirstServed(takeOutOrders, dineInOrders[1..], servedOrders[1..]);
                else
                if (takeOutOrders.Length > 0 && servedOrders.Length > 0 && servedOrders[0] == takeOutOrders[0])
                    return IsFirstComeFirstServed(takeOutOrders[1..], dineInOrders, servedOrders[1..]);

                return false;
            }

            return IsFirstComeFirstServed(new Span<int>(takeOutOrders), new Span<int>(dineInOrders), new Span<int>(servedOrders));
        }

        public bool IsFirstComeFirstServedQuick(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {
            // Check if we're serving orders first-come, first-served

            int[] Dump(int[] a)
            {
                System.Console.WriteLine(string.Join(',', a));
                return a;
            }

            Dump(takeOutOrders);
            Dump(dineInOrders);
            Dump(servedOrders);

            var (pTakeout, pDineIn, pServed) = (0, 0, 0);
            for (int i = 0; i < servedOrders.Length; i++)
            {
                if (pServed < servedOrders.Length && pTakeout < takeOutOrders.Length && servedOrders[pServed] == takeOutOrders[pTakeout])
                {
                    pServed++;
                    pTakeout++;
                    Console.WriteLine($"Takeout-{i},{pTakeout},{pDineIn},{pServed}");
                }
                else
                if (pServed < servedOrders.Length && pDineIn < dineInOrders.Length && servedOrders[pServed] == dineInOrders[pDineIn])
                {
                    pServed++;
                    pDineIn++;
                    Console.WriteLine($"DineIn-{i},{pTakeout},{pDineIn},{pServed}");
                }
                else
                {
                    Console.WriteLine($"Neither-{i},{pTakeout},{pDineIn},{pServed}");
                    return false;
                }
            }

            if (pServed == servedOrders.Length && pDineIn == dineInOrders.Length && pTakeout == takeOutOrders.Length)
                return true;

            return false;
        }

        [Test]
        public void BothRegistersHaveSameNumberOfOrdersTest()
        {
            var takeOutOrders = new int[] { 1, 4, 5 };
            var dineInOrders = new int[] { 2, 3, 6 };
            var servedOrders = new int[] { 1, 2, 3, 4, 5, 6 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.True(result);
        }

        [Test]
        public void RegistersHaveDifferentLengthsTest()
        {
            var takeOutOrders = new int[] { 1, 5 };
            var dineInOrders = new int[] { 2, 3, 6 };
            var servedOrders = new int[] { 1, 2, 6, 3, 5 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.False(result);
        }

        [Test]
        public void OneRegisterIsEmptyTest()
        {
            var takeOutOrders = new int[] { };
            var dineInOrders = new int[] { 2, 3, 6 };
            var servedOrders = new int[] { 2, 3, 6 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.True(result);
        }

        [Test]
        public void ServedOrdersIsMissingOrdersTest()
        {
            var takeOutOrders = new int[] { 1, 5 };
            var dineInOrders = new int[] { 2, 3, 6 };
            var servedOrders = new int[] { 1, 6, 3, 5 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.False(result);
        }

        [Test]
        public void ServedOrdersHasExtraOrders()
        {
            var takeOutOrders = new int[] { 1, 5 };
            var dineInOrders = new int[] { 2, 3, 6 };
            var servedOrders = new int[] { 1, 2, 3, 5, 6, 8 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.False(result);
        }

        [Test]
        public void OneRegisterHasExtraOrders()
        {
            var takeOutOrders = new int[] { 1, 9 };
            var dineInOrders = new int[] { 7, 8 };
            var servedOrders = new int[] { 1, 7, 8 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.False(result);
        }

        [Test]
        public void OneRegisterHasUnservedOrders()
        {
            var takeOutOrders = new int[] { 55, 9 };
            var dineInOrders = new int[] { 7, 8 };
            var servedOrders = new int[] { 1, 7, 8, 9 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.False(result);
        }

        [Test]
        public void OrderNumbersAreNotSequential()
        {
            var takeOutOrders = new int[] { 27, 12, 18 };
            var dineInOrders = new int[] { 55, 31, 8 };
            var servedOrders = new int[] { 55, 31, 8, 27, 12, 18 };
            // var result = IsFirstComeFirstServedRecursive(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            // var result = IsFirstComeFirstServedRecursiveSpan(takeOutOrders, dineInOrders, servedOrders);
            var result = IsFirstComeFirstServedQuick(takeOutOrders, dineInOrders, servedOrders);
            Assert.True(result);
        }


    }
}
