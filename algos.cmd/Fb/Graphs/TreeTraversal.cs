using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace algos.Fb
{

    [TestFixture]
    public class TreeTraversal
    {
        public int[] Bfs(TreeNode root)
        {
            /*  
                          1
                        /  \
                       2    3
                     /  \  / \
                    4   5  6  7
            */

            List<int> treeArray = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.TryPeek(out var _))
            {
                var n = q.Dequeue();
                treeArray.Add(n.Value);

                if (n.Left != null)
                    q.Enqueue(n.Left);

                if (n.Right != null)
                    q.Enqueue(n.Right);
            }
            return treeArray.ToArray();
        }

        [Test]
        public void TreeFromString()
        {
            var r = TreeNode.FromString("1,2,3,4,5");
            var r2 = TreeNode.FromString("1,2,3,null,4,5");
        }

        [Test]
        public void Traverse_Bfs()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var root = new TreeNode(1);

            var a = root.Left = new TreeNode(2);
            var b = root.Right = new TreeNode(3);

            var c = a.Left = new TreeNode(4);
            var d = a.Right = new TreeNode(5);

            var e = b.Left = new TreeNode(6);
            var f = b.Right = new TreeNode(7);

            var actual = Bfs(root);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Traverse_Bfs_nullNode()
        {
            var expected = new int[] { 1, 2, 0, 4 };
            var root = new TreeNode(1);

            var a = root.Left = new TreeNode(2);

            var c = a.Left = new TreeNode(4);

            var actual = Bfs(root);

            Console.WriteLine(root);

            //Assert.AreEqual(expected,actual);
        }


        public int[] Dfs_Inorder(TreeNode root)
        {
            throw new NotImplementedException();
        }

        public int[] Dfs_preorder(TreeNode root)
        {
            throw new NotImplementedException();
        }

        public int[] Dfs_postorder(TreeNode root)
        {
            throw new NotImplementedException();
        }
    }
}