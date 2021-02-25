/*
Traverse a tree Breatdh first
*/

using NUnit.Framework;
using System.Collections.Generic;

namespace algos.Fb
{
    [TestFixture]
    public class Traversal
    {
        public class Node
        {
            public Node(int value)
            {
                this.Value = value;
            }
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node AddLeft(int leftValue) => Left = new Node(leftValue);
            public Node AddRight(int rightValue) => Right = new Node(rightValue);

            public override string ToString()
            {
                return $"[{Value}]";
            }

        }

        public int[] Dfs_InOrder(Node root)
        {
            System.Console.WriteLine("InOrder");
            List<int> l = new List<int>();
            void Visit(Node n)
            {
                if (n == null)
                    return;

                Visit(n.Left);

                l.Add(n.Value);
                System.Console.WriteLine(n);

                Visit(n.Right);
            }

            Visit(root);
            return l.ToArray();
        }
        public int[] Dfs_PreOrder(Node root)
        {
            System.Console.WriteLine("PreOrder");
            List<int> l = new List<int>();

            void Visit(Node n)
            {
                if (n == null)
                    return;

                l.Add(n.Value);
                System.Console.WriteLine(n);

                Visit(n.Left);
                Visit(n.Right);
            }

            Visit(root);
            return l.ToArray();
        }
        public int[] Dfs_PostOrder(Node root)
        {
            System.Console.WriteLine("PostOrder");
            List<int> l = new List<int>();

            void Visit(Node n)
            {
                if (n == null)
                    return;

                Visit(n.Left);
                Visit(n.Right);

                l.Add(n.Value);
                System.Console.WriteLine(n);
            }

            Visit(root);
            return l.ToArray();
        }


        [Test]
        public void Test_TraverseTree_InOrder()
        {
            var r = new Node(1);
            var n2 = r.AddLeft(2);
            var n3 = r.AddRight(3);
            var n4 = n2.AddLeft(4);
            var n5 = n2.AddRight(5);

            var path = Dfs_InOrder(r);
            var expected = new int[] { 4, 2, 5, 1, 3 };
            Assert.AreEqual(expected, path);
        }

        [Test]
        public void Test_TraverseTree_PreOrder()
        {
            var r = new Node(1);
            var n2 = r.AddLeft(2);
            var n3 = r.AddRight(3);
            var n4 = n2.AddLeft(4);
            var n5 = n2.AddRight(5);

            var path = Dfs_PreOrder(r);
            var expected = new int[] { 1, 2, 4, 5, 3 };
            Assert.AreEqual(expected, path);
        }

        [Test]
        public void Test_TraverseTree_PostOrder()
        {
            var r = new Node(1);
            var n2 = r.AddLeft(2);
            var n3 = r.AddRight(3);
            var n4 = n2.AddLeft(4);
            var n5 = n2.AddRight(5);

            var path = Dfs_PostOrder(r);
            var expected = new int[] { 4, 5, 2, 3, 1 };
            Assert.AreEqual(expected, path);
        }
    }
}