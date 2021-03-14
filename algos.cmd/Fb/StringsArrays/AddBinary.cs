using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Fb.StringsArrays
{
    [TestFixture]
    public class AddBinary
    {
        public string Add(string a, string b)
        {
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;

            char[] binarySumArray = new char[(a.Length > b.Length ? a.Length : b.Length) + 1];
            Array.Fill<char>(binarySumArray, '0');
            int k = binarySumArray.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int x = i>=0? a[i] - '0': 0;
                int y = j>=0? b[j] - '0': 0;
                int sum = x + y + carry;

                binarySumArray[k] = (char)(sum % 2 + (int)'0');
                carry = sum / 2;

                i--;
                j--;
                k--;
            }

            binarySumArray = binarySumArray[0] == '0' ? binarySumArray[1..] : binarySumArray;

            return new string(binarySumArray);
        }

        [Test]
        public void Test()
        {
            string r = "";
            
            r = Add("1", "1");
            Assert.AreEqual("10",r);

            r = Add("1", "0");
            Assert.AreEqual("1", r);

            r = Add("1010", "1011");
            Assert.AreEqual("10101", r);
        }
    }
}
