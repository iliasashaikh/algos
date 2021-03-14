using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace algos.Fb.StringsArrays
{
    [TestFixture]
    public class Anagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {
                var sign = MakeSignature(s);
                var group = groups.TryGetValue(sign, out var r) ? r : new List<string>();
                group.Add(s);
                groups[sign] = group;
            }
            return new List<IList<string>>(groups.Values);

            //List<IList<string>> result = new List<IList<string>>();
            //foreach (var key in groups.Keys)
            //{
            //    var l = groups[key];
            //    result.Add(l);
            //}

            //return result;
        }

        public string MakeSignature2(string s)
        {
            int[] sign = new int[26];
            Array.Fill(sign, 0);

            for (int i = 0; i < s.Length; i++)
            {
                sign[s[i] - 'a']++;
            }

            //return new string(sign.Cast<char>().ToArray());
            StringBuilder sb = new StringBuilder();
            foreach (var si in sign)
            {
                sb.Append(si).Append("#");
            }

            return sb.ToString();
        }

        public string MakeSignature(string s)
        {
            int[] intsign = new int[26];

            Array.Fill(intsign, 0);

            for (int i = 0; i < s.Length; i++) 
            {
                intsign[(s[i] - 'a')]++;
            }

            var sign = string.Join("#", intsign.Select(i => i.ToString()).ToArray());

            return sign;
        }

        [Test]
        public void Test()
        {
            var r = GroupAnagrams(new string[] {"bdddddddddd", "bbbbbbbbbbc"});
            Assert.AreEqual(2, r.Count);
        }
    }
}

