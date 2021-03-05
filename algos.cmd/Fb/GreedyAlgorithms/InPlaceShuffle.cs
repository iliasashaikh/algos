/*


Write a method for doing an in-place ↴ shuffle of an array.

The shuffle must be "uniform," meaning each item in the original array must have the same probability of ending up in each spot in the final array.

Assume that you have a method GetRandom(floor, ceiling) for getting a random integer that is >= floor and <= ceiling.

*/
using System;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class InPlaceShuffle
    {
        static Random _rand = new Random();

        static int GetRandom(int floor, int ceiling)
        {
            return _rand.Next(floor, ceiling + 1);
        }

        public static void Shuffle(int[] array)
        {
            // Shuffle the input in place
            for (int i = 0; i < array.Length; i++)
            {
                var newIndex = GetRandom(i, array.Length - 1);
                (array[i], array[newIndex]) = (array[newIndex], array[i]);
            }
        }

        [Test]
        public void Test()
        {
            var initial = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var shuffled = (int[])initial.Clone();
            Shuffle(shuffled);
            Console.WriteLine($"Initial array: [{string.Join(", ", initial)}]");
            Console.WriteLine($"Shuffled array: [{string.Join(", ", shuffled)}]");
        }
    }
}