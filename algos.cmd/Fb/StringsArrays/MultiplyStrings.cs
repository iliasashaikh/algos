using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.StringsArrays
{
    [TestFixture]
    public class MultiplyStrings
    {

        /*
       123 * 45 = 

        123
        45
        
        a = 5, b = 3 => c = 15, product = 5, carry = 1
        a = 5, b = 2 => c = 11, product = 15, carry = 1
        a = 5, b = 1 => c = 5, product = 100 , carry = 1
                
         */
        public string Multiply2(string num1, string num2)
        {
            if (num2.Length > num1.Length)
                Multiply2(num2, num1);

            long ans = 0;

            var ca = num1.ToCharArray();
            Array.Reverse(ca);
            num1 = new string(ca);

            ca = num2.ToCharArray();
            Array.Reverse(ca);
            num2 = new string(ca);

            for (int i = 0; i < num2.Length; i++)
            {

                long carry = 0;
                long product = 0;
                for (int j = 0; j < num1.Length; j++)
                {
                    var a = long.Parse(num2[i].ToString());
                    var b = long.Parse(num1[j].ToString());

                    var c = a * b + carry;
                    product = product + (long)Math.Pow(10, j) * (c % 10);
                    carry = c / 10;
                }
                // any carry?
                if (carry > 0)
                    product = product + (long)Math.Pow(10, num1.Length) * carry;
                
                ans = product * (long)Math.Pow(10, i) + ans;
            
            }

            return ans.ToString();
        }

        public string Multiply(string num1, string num2)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Test()
        {
            var r = Multiply2("123", "45");
            Assert.AreEqual("5535", r);

            r = Multiply2("123", "1");
            Assert.AreEqual("123", r);

            r = Multiply2("123", "0");
            Assert.AreEqual("0", r);

            r = Multiply2("9", "8");
            Assert.AreEqual("72", r);

            r = Multiply2("9", "99");
            Assert.AreEqual("891", r);
        }
    }
}
