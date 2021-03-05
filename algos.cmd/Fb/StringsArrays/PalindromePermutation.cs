/*

Write an efficient method that checks whether any permutation ↴ of an input string is a palindrome. ↴

You can assume the input string only contains lowercase letters.

Examples:

"civic" should return true
"ivicc" should return true
"civil" should return false
"livci" should return false
"But 'ivicc' isn't a palindrome!"

If you had this thought, read the question again carefully. We're asking if any permutation of the string is a palindrome. Spend some extra time ensuring you fully understand the question before starting. Jumping in with a flawed understanding of the problem doesn't look good in an interview.

*/
using System.Collections.Generic;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class PalindromePermutation
    {
        public static bool HasPalindromePermutation(string theString)
        {
            // Check if any permutation of the input is a palindrome

            HashSet<char> unpairedCharacters = new HashSet<char>();
            foreach (var c in theString)
            {
                if (unpairedCharacters.Contains(c))
                    unpairedCharacters.Remove(c);
                else
                    unpairedCharacters.Add(c);
            }


            return unpairedCharacters.Count <= 1;
        }

        // Tests

        [Test]
        public void PermutationWithOddNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabcbcd");
            Assert.True(result);
        }

        [Test]
        public void PermutationWithEvenNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabccbdd");
            Assert.True(result);
        }

        [Test]
        public void NoPermutationWithOddNumberOfChars()
        {
            var result = HasPalindromePermutation("aabcd");
            Assert.False(result);
        }

        [Test]
        public void NoPermutationWithEvenNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabbcd");
            Assert.False(result);
        }

        [Test]
        public void EmptyStringTest()
        {
            var result = HasPalindromePermutation("");
            Assert.True(result);
        }

        [Test]
        public void OneCharacterStringTest()
        {
            var result = HasPalindromePermutation("a");
            Assert.True(result);
        }
    }
}