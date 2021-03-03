/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

1 - 
2 - abc
3 - def
4 - ghi
5 - jkl
6 - mno
7 - pqrs
8 - tuv
9 - wxyz

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
Example 2:

Input: digits = ""
Output: []
Example 3:

Input: digits = "2"
Output: ["a","b","c"]
 

Constraints:

0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
 
 */


using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    [TestFixture]
    public class PhoneLetterCombinations
    {

        Dictionary<string, string> mapping = new Dictionary<string, string>
        {
            ["2"] = "abc",
            ["3"] = "def",
            ["4"] = "ghi",
            ["5"] = "jkl",
            ["6"] = "mno",
            ["7"] = "pqrs",
            ["8"] = "tuv",
            ["9"] = "wxyz"
        };
        public IList<string> LetterCombinations(string digits)
        {
            var combinations = new List<string>() { "" };

            foreach (var digit in digits)
            {
                var nextCombinations = new List<string>();
                foreach (var combination in combinations)
                {
                    foreach (var c in mapping[digit.ToString()])
                    {
                        nextCombinations.Add(combination + c);
                    }
                }

                combinations = nextCombinations;
            }

            return combinations;

        }

        //public IList<string> LetterCombinationsRecurse(string digits)
        //{

        //    var combinations = new List<string>();

        //    void backtrack(string combination, string digits)
        //    {
        //        if (digits.Length == 0)
        //        {
        //            combinations.Add(combination);
        //        }
        //        else
        //        {
        //            var currentDigit = digits[0];
        //            var letters = mapping[currentDigit];
        //            foreach (var letter in letters)
        //            {
        //                combination += letter;
        //                backtrack(combination, )
        //            }
        //        }


        //    }




        //}

        [Test]
        public void Test()
        {
            var r = LetterCombinations("23");
        }
    }

  
}
