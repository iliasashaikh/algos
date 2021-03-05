using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace algos
{
    /*
     * Pair Sums
     * Given a list of n integers arr[0..(n-1)], determine the number of different pairs of elements within it which sum to k.
     * 
        If an integer appears in the list multiple times, each copy is considered to be different; 
            that is, two pairs are considered different if one pair includes at least one array index which the other doesn't, even if they include the same values.

        Signature
        int numberOfWays(int[] arr, int k)
        Input
        n is in the range [1, 100,000].
        Each value arr[i] is in the range [1, 1,000,000,000].
        k is in the range [1, 1,000,000,000].
        Output
        Return the number of different pairs of elements which sum to k.

        Example 1
        n = 5
        k = 6
        arr = [1, 2, 3, 4, 3]
        output = 2
        The valid pairs are 2+4 and 3+3.

        Example 2
        n = 5
        k = 6
        arr = [1, 5, 3, 3, 3]
        output = 4
        There's one valid pair 1+5, and three different valid pairs 3+3 (the 3rd and 4th elements, 3rd and 5th elements, and 4th and 5th elements).
     */
    [TestFixture]
    public class SumPairs
    {
        private int numberOfWaysBruteForce(int[] arr, int k)
        {
            int count = 0;
            var occurances = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == k && i != j)
                        count++;
                }

            return count / 2;
        }

        private int numberOfWays(int[] arr, int k)
        {
            int count = 0;
            var occurances = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                occurances[arr[i]] = occurances.TryGetValue(arr[i], out var v) ? ++v : 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var offset = k - arr[i];
                if (occurances.TryGetValue(offset, out var v))
                {
                    count += occurances[offset];
                }
                if (offset == arr[i])
                    count--;
            }

            Console.WriteLine(occurances);
            return count / 2;
        }


        public void Run()
        {
            var r = numberOfWaysBruteForce(new int[] { 1, 5, 3, 3, 3 }, 6);
            Console.WriteLine(r);

            r = numberOfWays(new int[] { 1, 5, 3, 3, 3 }, 6);
            Console.WriteLine(r);
        }
    }
}
