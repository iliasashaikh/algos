using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
        [TestFixture]
    public class AlienDictionary
    {
        public bool IsSorted(string[] words, string order)
        {
            var orderMap = MakeLexMap(order);

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!IsSorted(words[i], words[i + 1],orderMap))
                    return false;
            }

            return true;
        }

        private Dictionary<char,int> MakeLexMap(string order)
        {
            var d = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                d[order[i]] = i;
            }

            return d;
        }

        private bool IsSorted(string a, string b, Dictionary<char,int> orderMap)
        {
            (a, b) = a.Length > b.Length ? (b, a) : (a, b);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) 
                    return IsSorted(a[i], b[i], orderMap);
            }

            return true;
        }

        private bool IsSorted(char v, char v1, Dictionary<char, int> orderMap)
        {
            var r = orderMap[v] <= orderMap[v1];
            return r;
        }

        [Test]
        public void Test()
        {
            var r = IsSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");
            Assert.True(r);

            r = IsSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz");
            Assert.False(r);
        }
    }
}
