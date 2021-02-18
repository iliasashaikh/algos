using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos
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

    public static class MininumWindowSubstring
    {
        public static string BruteForce(string s, string t)
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

        public static string SlidingWindow()
        {

            string ContainsFast(ref string a,ref  string b)
            {
                var dictA = new Dictionary<char, int>();
                var dictB = new Dictionary<char, int>();
                for (int i = 0; i < b.Length; i++)
                
                if (a.Length >= b.Length)
                {
                    foreach (var c in a)
                    {

                    }
                }

                
            }

            var (s, t) = (0, 0);



        }

        public static void Run()
        {
            BruteForce("A", "A");
            BruteForce("ADOBECODEBANC", "ABC");
            BruteForce("A", null);
            BruteForce(null, null);
            BruteForce(null, "A");
            BruteForce("abc", "AB");
            BruteForce("abc", "a");
            BruteForce("a", "a");
        }
    }
}
