using System;
using System.Collections.Generic;
using System.Text;

namespace algos
{
    /*
     * Given a string s, find the length of the longest substring without repeating characters.

        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.
        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
        Example 4:

        Input: s = ""
        Output: 0
 

        Constraints:

        0 <= s.length <= 5 * 104
        s consists of English letters, digits, symbols and spaces.
     */
    public static class LongestSubstring
    {
        public static void Run()
        {
            //Console.WriteLine(Bruteforce("abcabcbb"));
            //Console.WriteLine(Bruteforce("bbbbb"));
            //Console.WriteLine(Bruteforce("pwwkew"));

            Console.WriteLine(SlidingWindow("abcabcbb"));
            Console.WriteLine(SlidingWindow("abcbabcbb"));
            Console.WriteLine(SlidingWindow("bbbbb"));
            Console.WriteLine(SlidingWindow("pwwkew"));

        }

        static int Bruteforce(string s)
        {
            var longestSubstring = "";

            for (int i = 0; i < s.Length; i++)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(s[i]);
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (!sb.ToString().Contains(s[j]))
                        sb.Append(s[j]);
                    else
                        break;
                }

                if (sb.ToString().Length > longestSubstring.Length)
                    longestSubstring = sb.ToString();
            }
            Console.WriteLine($"{s}:{longestSubstring}");
            return longestSubstring.Length;
        }

        static int SlidingWindow(string s)
        {

            if (s == null || s?.Length == 0)
                return 0;

            int maxLength = 0;
            var (left, right) = (0,0);
            HashSet<char> substringChars = new HashSet<char>();
            while (right < s.Length)
            {
                if (substringChars.Contains(s[right]))
                {
                    substringChars.Remove(s[left]);
                    left++;
                }
                else
                {
                    substringChars.Add(s[right]);
                    maxLength = Math.Max(maxLength, right - left + 1);
                    right++;
                }

            }

            return maxLength;

        }
    }
}
