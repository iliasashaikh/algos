using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Fb
{
    [TestFixture]
    public class ReverseWords
    {
        public void Reverse(char[] message)
        {

            // reverse the entire message if theres any space
            if ( (message?.Any() ?? false) && message.Contains(' '))
            {
                Reverse(message, 0, message.Length - 1);

                int start = 0;

                for (int i = 0; i <= message.Length; i++)
                {
                    // Check for length before empty string
                    if (i == message.Length || message[i] == ' ')
                    {
                        Reverse(message, start, i - 1);
                        start = i + 1;
                    }
                }

                //Reverse(message, start, message.Length - 1);
            }

        }

        void Reverse(char[] message, int start, int end)
        {
            while(start<end)
            {
                var a = message[start];
                var b = message[end];

                message[start] = b;
                message[end] = a;

                start++;
                end--;
            }
        }
        

        // Tests

        [Test]
        public void OneWordTest()
        {
            var expected = "vault".ToCharArray();
            var actual = "vault".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoWordsTest()
        {
            var expected = "cake thief".ToCharArray();
            var actual = "thief cake".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ThreeWordsTest()
        {
            var expected = "get another one".ToCharArray();
            var actual = "one another get".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultipleWordsSameLengthTest()
        {
            var expected = "the cat ate the rat".ToCharArray();
            var actual = "rat the ate cat the".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultipleWordsDifferentLengthsTest()
        {
            var expected = "chocolate bundt cake is yummy".ToCharArray();
            var actual = "yummy is cake bundt chocolate".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyStringTest()
        {
            var expected = "".ToCharArray();
            var actual = "".ToCharArray();
            Reverse(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
