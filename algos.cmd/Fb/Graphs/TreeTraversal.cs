using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace algos.Fb
{

    [TestFixture]
    public class TreeTraversal
    {
        public int[] Bfs(Node root)
        {
            /*  
                          1
                        /  \
                       2    3
                     /  \  / \
                    4   5  6  7
            */

            List<int> treeArray = new List<int>();
            Queue<Node> q = new Queue<Node>();
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
            var r = Node.FromString("1,2,3,4,5");
            var r2 = Node.FromString("1,2,3,null,4,5");
        }

        [Test]
        public void Traverse_Bfs()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var root = new Node(1);

            var a = root.Left = new Node(2);
            var b = root.Right = new Node(3);

            var c = a.Left = new Node(4);
            var d = a.Right = new Node(5);

            var e = b.Left = new Node(6);
            var f = b.Right = new Node(7);

            var actual = Bfs(root);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Traverse_Bfs_nullNode()
        {
            var expected = new int[] { 1, 2, 0, 4 };
            var root = new Node(1);

            var a = root.Left = new Node(2);

            var c = a.Left = new Node(4);

            var actual = Bfs(root);

            Console.WriteLine(root);

            //Assert.AreEqual(expected,actual);
        }


        public int[] Dfs_Inorder(Node root)
        {
            throw new NotImplementedException();
        }

        public int[] Dfs_preorder(Node root)
        {
            throw new NotImplementedException();
        }

        public int[] Dfs_postorder(Node root)
        {
            throw new NotImplementedException();
        }
    }
}