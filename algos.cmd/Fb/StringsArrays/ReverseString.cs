using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    [TestFixture]
    public class ReverseString
    {

        public static void Reverse(char[] arrayOfChars)
        {
            // Reverse input array of characters in place

            if (arrayOfChars != null && arrayOfChars.Length > 1)
            {
                int length = arrayOfChars.Length;

                for (int i = 0; i < length / 2; i++)
                {
                    (arrayOfChars[i], arrayOfChars[length - 1 - i]) =
                    (arrayOfChars[length - 1 - i], arrayOfChars[i]);
                }
            }
        }


        [Test]
        public void EmptyStringTest()
        {
            var expected = "".ToCharArray();
            var actual = "".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleCharacterStringTest()
        {
            var expected = "A".ToCharArray();
            var actual = "A".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LongerStringTest()
        {
            var expected = "EDCBA".ToCharArray();
            var actual = "ABCDE".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

    }
}
