using NUnit.Framework;
using System.Collections.Generic;

namespace algos.Fb
{
    [TestFixture]
    public class BinaryTreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root) 
        {
            var q = new Queue<TreeNode>();
            var rightSideNodes = new List<int>();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                var n = q.Dequeue();
                if (n.Right == null)
                    rightSideNodes.Add(n.Value);
                else
                    q.Enqueue(n.Right);

                if (n.Left != null)
                    q.Enqueue(n.Left);
            }

            return rightSideNodes;
        }

        [Test]
        public void TestRightSideView()
        {
            var treeString = "1,2,3,null,4,5,6";
            var expected = new List<int>{3,6};

            var actual = RightSideView(TreeNode.FromString(treeString));

            Assert.AreEqual(expected,actual);
        }
    }
}
