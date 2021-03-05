using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    [TestFixture]
    public class PermutationsNoDups
    {
        public List<string> Permute(string s)
        {
            if (s == "")
                return new List<string> { "" };


            var permutations = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                var partial = Permute(s[0..i] + s[(i+1)..]);
                foreach (var item in partial)
                {
                    permutations.Add(s[i] + item);
                }
            }

            return permutations;
       }

        [Test]
        public void TestPermutations()
        {
            var r = Permute("abc");
        }
    }
}
