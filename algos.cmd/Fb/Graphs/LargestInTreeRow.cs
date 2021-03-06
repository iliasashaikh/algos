using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    /*
     [1,2,3,4,5,6]
            
                1
                / \
              2    3
            / \      \
            4   5    6
    
    l[0] = 1
    l[1] = 2
    l[2] = 4
    
     */
    [TestFixture]
    public class LargestInTreeRow
    {
        List<int> levels = new List<int>();
        public int[] FindRecursive(Node root)
        {

            void Find(Node n, int level)
            {
                if (n == null)
                    return;

                if (levels.Count > level)
                    levels[level] = Math.Max(levels[level], n.Value);
                else
                    levels.Add(n.Value);

                Find(n.Left, level + 1);
                Find(n.Right, level + 1);
            }

            Find(root, 0);

            return levels.ToArray();

        }

        [Test]
        public void Test()
        {
            var n = Node.FromString("1,2,3,4,5,null,6");
            var r = FindRecursive(n);
            Assert.AreEqual(r, new int[] {1,3,6});
        }
    }
}
