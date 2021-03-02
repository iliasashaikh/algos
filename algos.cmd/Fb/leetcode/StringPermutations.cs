using System.Collections.Generic;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class StringPermutations
    {
        public ISet<string> GetPermutations(string inputString)
        {
            // Base case
            if (inputString.Length <= 1)
            {
                return new HashSet<string>() { inputString };
            }

            var allCharsExceptLast = inputString.Substring(0, inputString.Length - 1);
            char lastChar = inputString[inputString.Length - 1];

            // Recursive call: get all possible permutations for all chars except last
            var permutationsOfAllCharsExceptLast = GetPermutations(allCharsExceptLast);

            // Put the last char in all possible positions for each of the above permutations
            var permutations = new HashSet<string>();
            foreach (var permutationOfAllCharsExceptLast in permutationsOfAllCharsExceptLast)
            {
                for (int position = 0; position <= allCharsExceptLast.Length; position++)
                {
                    var permutation = permutationOfAllCharsExceptLast.Substring(0, position)
                        + lastChar + permutationOfAllCharsExceptLast.Substring(position);
                    permutations.Add(permutation);
                }
            }

            return permutations;
        }
        public List<string> Permute(string s)
        {
            if (s.Length <= 1)
                return new List<string> { s };

            var lastChar = s[^1];
            var allButLast = s[0..^1];
            var permutationsAllExceptLast = Permute(allButLast);
            var allPermutations = new List<string>();
            for (int i = 0; i < permutationsAllExceptLast.Count; i++)
            {
                for (int j = 0; j <= allButLast.Length; j++)
                {
                    var permutation = permutationsAllExceptLast[i];
                    var newString = permutation[0..j] + lastChar + permutation[j..];
                    allPermutations.Add(newString);
                }
            }
            return allPermutations;
        }

        [Test]
        public void TestPermute()
        {
            //var l = GetPermutations("abc");
            var l = Permute("abc");

        }
    }
}