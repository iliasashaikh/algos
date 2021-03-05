using NUnit.Framework;
using System.Collections.Generic;

namespace algos.Fb
{
    [TestFixture]
    public class FlattenBinaryTree
    {
        public Node Flatten_UsingList(Node root)
        {
            var inorderSequence = new List<Node>();

            void Do(Node n)
            {
                if (n == null)
                    return;

                inorderSequence.Add(n);

                Do(n.Left);
                Do(n.Right);
            }

            Do(root);

            for (int i = 0; i < inorderSequence.Count - 1; i++)
            {
                inorderSequence[i].Left = null;
                inorderSequence[i].Right = inorderSequence[i + 1];
            }

            return root;
        }

        public Node Flatten_Recursive(Node node)
        {
            if (node == null)
                return null;

            if (node.Left == null && node.Right == null)
                return node;

            var left = Flatten_Recursive(node.Left);
            var right = Flatten_Recursive(node.Right);

            if (left != null)
            {
                left.Right = node.Right;
                node.Right = node.Left;
                node.Left = null;
            }

            return right == null ? left : right;
        }

        [Test]
        public void TestFlatten_UsingList()
        {
            var tree = Node.FromString("1,2,5,3,4,null,6");
            var lk = Flatten_UsingList(tree);
            var expected = "1,null,2,null,3,null,4,null,5,null,6";
            Assert.AreEqual(expected, lk.ToString());
        }

        [Test]
        public void TestFlatten_Recursive()
        {
            var tree = Node.FromString("1,2,5,3,4,null,6");
            var lk = Flatten_Recursive(tree);
            var expected = "1,null,2,null,3,null,4,null,5,null,6";
            Assert.AreEqual(expected, lk.ToString());
        }
    }
}