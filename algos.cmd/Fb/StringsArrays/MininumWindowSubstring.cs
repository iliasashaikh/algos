using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace algos.Fb.StringsArrays
{
    /*
     *  Given two strings s and t, return the minimum window in s which will contain all the characters in t. I
     *  f there is no such window in s that covers all characters in t, return the empty string "".

        Note that If there is such a window, it is guaranteed that there will always be only one unique minimum window in s.
 

        Example 1:

        Input: s = "ADOBECODEBANC", t = "ABC"
        Output: "BANC"
        Example 2:

        Input: s = "a", t = "a"
        Output: "a"
 

        Constraints:

        1 <= s.length, t.length <= 105
        s and t consist of English letters.
 

        Follow up: Could you find an algorithm that runs in O(n) time? 
     * 
     */
    [TestFixture]
    public class MininumWindowSubstring
    {
        public string BruteForce(string s, string t)
        {
            bool IsCover(string subString, string t)
            {
                if (subString.Length >= t.Length)
                {
                    var a = new string(subString.OrderBy(c => c).ToArray());
                    var b = new string(t.OrderBy(c => c).ToArray());

                    return a.Contains(b);

                }

                return false;
            }

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return "";

            int minLength = int.MaxValue;
            string minCoverString = null;
            for (int i = 0; i < s.Length; i++)
                for (int j = i; j < s.Length; j++)
                {
                    var substring = s.Substring(i, j - i + 1);
                    if (IsCover(substring, t))
                    {
                        if (substring.Length == Math.Min(minLength,substring.Length))
                        {
                            minLength = substring.Length;
                            minCoverString = substring;
                        }
                    }
                }

            Console.WriteLine($"{s}/{t}:{minCoverString}");
            return minCoverString;
            
        }

        public string SlidingWindow(string s, string t)
        {
            // s=xaxbxx; t=ab; => axb
            int left = 0;
            int right = 0;
            var s2 = s.AsSpan();
            int minWindowLength = int.MaxValue;
            string minWindow = "";

            while (right < s2.Length)
            {
                var window = s2[left..(right + 1)];
                if (IsCover(window,t))
                {
                    var minWin = FindMinWindow(window, t);
                    if (minWin.Length < minWindowLength)
                        minWindow = minWin;

                    left = right + 1;
                }
                right++;
            }

            return minWindow;
        }

        private string FindMinWindow(ReadOnlySpan<char> window, string t)
        {
            int left = 0;
            var origWindow = window;
            while(left < window.Length)
            {
                window = window[(left)..];
                if (!IsCover(window, t))
                    return origWindow[(left-1)..].ToString();
                left++;
            }

            return t;
        }

        private bool IsCover(ReadOnlySpan<char> window, string t)
        {
            var a = window.ToArray();
            Array.Sort(a);
            var windowSorted = new string(a);

            var b = t.ToCharArray();
            Array.Sort(b);
            var targetSorted = new string(b);

            return windowSorted.Contains(t);
        }

        [Test]
        public void Test()
        {
            var r = SlidingWindow("ADOBECODEBANC", "ABC");
            Assert.AreEqual("BANC", r);

            //BruteForce("A", "A");
            //BruteForce("ADOBECODEBANC", "ABC");
            //BruteForce("A", null);
            //BruteForce(null, null);
            //BruteForce(null, "A");
            //BruteForce("abc", "AB");
            //BruteForce("abc", "a");
            //BruteForce("a", "a");
        }
    }
}
