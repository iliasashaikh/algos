using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algos.Fb.StringsArrays
{
    [TestFixture]
    public class ThreeSum
    {
        public IList<IList<int>> FindThreeSum(int[] nums)
        {
            var r = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                List<IList<int>> twoSums = TwoSum(nums[i], nums, i);
                foreach (var twoSum in twoSums)
                {
                    r.Add(twoSum);
                }
            }

            return (IList<IList<int>>)r;
        }

        //[-1, 0, 1, 2, -1, -4]
        
        //[-1]
        //0

        List<IList<int>> TwoSum(int current, int[] nums, int currentIndex)
        {
            //t=1
            //[0,1]
            HashSet<int> processed = new HashSet<int>();
            var target = 0 - current;
            var r = new List<IList<int>>();

            for (int i = currentIndex+1; i < nums.Length; i++)
            {
                
                var offset = target - nums[i];
                if (processed.Contains(offset))
                {
                    r.Add(new List<int> { nums[i], current, offset });
                }
                processed.Add(nums[i]);
            }

            return r;
        }

        [Test]
        public void Test1()
        {
            var r = FindThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            var expected = new List<List<int>>
            {
                new List<int>{-1,0,1 },
                new List<int>{-1,-1,2 },
                new List<int>{-1,-1,2 }
            };

            Assert.AreEqual(expected.Count, r.Count);

        }
    }
}
