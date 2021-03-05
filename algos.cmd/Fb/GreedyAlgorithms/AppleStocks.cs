/*
 Writing programming interview questions hasn't made me rich yet ... so I might give up and start trading Apple stocks all day instead.

First, I wanna know how much money I could have made yesterday if I'd been trading Apple stocks all day.

So I grabbed Apple's stock prices from yesterday and put them in an array called stockPrices, where:

    The indices are the time (in minutes) past trade opening time, which was 9:30am local time.
    The values are the price (in US dollars) of one share of Apple stock at that time.

So if the stock cost $500 at 10:30am, that means stockPrices[60] = 500.

Write an efficient method that takes stockPrices and returns the best profit I could have made from one purchase and one sale of one share of Apple stock yesterday.

For example:

  int[] stockPrices = { 10, 7, 5, 8, 11, 9 };

// Returns 6 (buying for $5 and selling for $11)
GetMaxProfit(stockPrices);

No "shorting"—you need to buy before you can sell. Also, you can't buy and sell in the same time step—at least 1 minute has to pass. 
*/

using System;
using static System.Math;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class AppleStocks
    {
        public int GetMaxProfitBruteForce(int[] stockPrices)
        {
            int maxProfit = int.MinValue;
            for (int i = 0; i < stockPrices.Length - 1; i++)
                for (int j = i; j < stockPrices.Length; j++)
                {
                    var buyAt = stockPrices[i];
                    var sellAt = stockPrices[j];

                    var profit = sellAt - buyAt;
                    maxProfit = Math.Max(maxProfit, profit);
                }

            return maxProfit;
        }

        public int GetMaxProfit(int[] stockPrices)
        {
            if (stockPrices == null || stockPrices.Length <= 1)
                throw new ArgumentException();

            int minPrice = stockPrices[0];
            int maxProfit = int.MinValue;

            for (int i = 1; i < stockPrices.Length; i++)
            {
                var profit = stockPrices[i] - minPrice;
                maxProfit = Max(profit, maxProfit);

                minPrice = Min(minPrice, stockPrices[i]);
            }

            return maxProfit;
        }



        // Tests

        [Test]
        public void PriceGoesUpThenDownTest()
        {
            // var actual = GetMaxProfitBruteForce(new int[] { 1, 5, 3, 2 });
            var actual = GetMaxProfit(new int[] { 1, 5, 3, 2 });
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PriceGoesDownThenUpTest()
        {
            // var actual = GetMaxProfitBruteForce(new int[] { 7, 2, 8, 9 });
            var actual = GetMaxProfit(new int[] { 7, 2, 8, 9 });
            var expected = 7;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BigIncreaseThenSmallIncreaseTest()
        {
            // var actual = GetMaxProfitBruteForce(new int[] { 2, 10, 1, 4 });
            var actual = GetMaxProfit(new int[] { 2, 10, 1, 4 });
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PriceGoesUpAllDayTest()
        {
            // var actual = GetMaxProfitBruteForce(new int[] { 1, 6, 7, 9 });
            var actual = GetMaxProfit(new int[] { 1, 6, 7, 9 });
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PriceGoesDownAllDayTest()
        {
            // var actual = GetMaxProfitBruteForce(new int[] { 9, 7, 4, 1 });
            var actual = GetMaxProfit(new int[] { 9, 7, 4, 1 });
            var expected = -2;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PriceStaysTheSameAllDayTest()
        {
            // var actual = GetMaxProfitBruteForce(new int[] { 1, 1, 1, 1 });
            var actual = GetMaxProfit(new int[] { 1, 1, 1, 1 });
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExceptionWithOnePriceTest()
        {
            Assert.Throws<ArgumentException>(() => GetMaxProfit(new int[] { 5 }));
        }

        [Test]
        public void ExceptionWithEmptyPricesTest()
        {
            Assert.Throws<ArgumentException>(() => GetMaxProfit(new int[] { }));
        }

    }
}