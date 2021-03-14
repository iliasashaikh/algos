using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.StringsArrays
{
    [TestFixture]
    public class WordAbbreviation
    {
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int wordIndex = 0;
            int abbrIndex = 0;

            while (wordIndex < word.Length && abbrIndex < abbr.Length)
            {
                if (word[wordIndex] != abbr[abbrIndex])
                {
                    if (char.IsLetter(word[wordIndex]) && char.IsLetter(abbr[abbrIndex]))
                        return false;

                    else
                    if (char.IsDigit(abbr[abbrIndex]))
                    {
                        if (abbr[abbrIndex] == '0')
                            return false;

                        int abbrNum = 0;
                        while (abbrIndex < abbr.Length && char.IsDigit(abbr[abbrIndex]))
                        {
                            abbrNum = abbrNum * 10 + int.Parse(abbr[abbrIndex].ToString());
                            abbrIndex++;
                        }
                        wordIndex += abbrNum;
                    }
                }
                else
                {
                    wordIndex++; 
                    abbrIndex++;
                }
            }

            if (wordIndex == word.Length && abbrIndex == abbr.Length)
                return true;

            return false;
        }

        [Test]
        public void Test()
        {
            var r = ValidWordAbbreviation("internationalization", "i5a11o1");
            Assert.True(r);
        }
    }


}
