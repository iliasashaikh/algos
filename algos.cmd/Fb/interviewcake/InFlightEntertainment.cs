/*

You've built an inflight entertainment system with on-demand movie streaming.

Users on longer flights like to start a second movie right when their first one ends, but they complain that the plane usually lands before they can see the ending. So you're building a feature for choosing two movies whose total runtimes will equal the exact flight length.

Write a method that takes an integer flightLength (in minutes) and an array of integers movieLengths (in minutes) and returns a boolean indicating whether there are two numbers in movieLengths whose sum equals flightLength.

When building your method:

Assume your users will watch exactly two movies
Don't make your users watch the same movie twice
Optimize for runtime over memory

*/
using System.Collections.Generic;
using NUnit.Framework;

namespace algos.Fb
{

    [TestFixture]
    public class InFlightEntertainment
    {
        public bool CanTwoMoviesFillFlight(int[] movieLengths, int flightLength)
        {
            HashSet<int> movieTimes = new HashSet<int>();
            for (int i = 0; i < movieLengths.Length; i++)
            {

            }


            return false;
        }
        // Tests

        [Test]
        public void ShortFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 2, 4 }, 1);
            Assert.False(result);
        }

        [Test]
        public void LongFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 2, 4 }, 6);
            Assert.True(result);
        }

        [Test]
        public void OnlyOneMovieHalfFlightLenghtTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 3, 8 }, 6);
            Assert.False(result);
        }

        [Test]
        public void TwoMoviesHalfFlightLengthTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 3, 8, 3 }, 6);
            Assert.True(result);
        }

        [Test]
        public void LotsOfPossiblePairsTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 1, 2, 3, 4, 5, 6 }, 7);
            Assert.True(result);
        }

        [Test]
        public void NotUsingFirstMovieTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 4, 3, 2 }, 5);
            Assert.True(result);
        }

        [Test]
        public void MultipleMoviesShorterThanFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 5, 6, 7, 8 }, 9);
            Assert.False(result);
        }

        [Test]
        public void OneMovieTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 6 }, 6);
            Assert.False(result);
        }

        [Test]
        public void NoMoviesTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { }, 6);
            Assert.False(result);
        }
    }
}