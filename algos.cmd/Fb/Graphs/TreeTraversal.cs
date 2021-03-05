using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace algos.Fb
{

    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            var q = new Queue<Node>();
            var l = new List<Node>();
            q.Enqueue(this);
            while (q.TryPeek(out _))
            {
                var n = q.Dequeue();
                l.Add(n);
                if (n != null)
                {
                    if (n.Left != null || n.Right != null)
                    {
                        q.Enqueue(n.Left);
                        q.Enqueue(n.Right);
                    }
                }
            }

            var s = string.Join(",", l.Select(n => n?.Value.ToString() ?? "null").ToArray());
            return s;
        }

        public static Node FromString(string treeString)
        {
            var q = new Queue<Node>();
            var treeStringArray = treeString.Split(',');
            var treeArray = treeStringArray.Select(s => int.TryParse(s, out var v) ? (int?)v : null).ToArray();

            var root = new Node(treeArray[0].Value);
            int nextLeft = 1;
            int nextRight = 2;

            var nextRoot = root;
            q.Enqueue(nextRoot);
            while (q.TryPeek(out _))
            {
                nextRoot = q.Dequeue();

                if (nextLeft < treeArray.Length)
                {
                    var l = treeArray[nextLeft] == null? null: new Node(treeArray[nextLeft].Value);
                    nextLeft += 2;
                    nextRoot.Left = l;
                    q.Enqueue(l);
                }

                if (nextRight < treeArray.Length)
                {
                    var r = treeArray[nextRight] ==null? null: new Node(treeArray[nextRight].Value);
                    nextRight += 2;
                    nextRoot.Right = r;
                    q.Enqueue(r);
                }
            }

            return root;
        }

        // public static Node FromString(string treeString)
        // {
        //     var treeStringArray = treeString.Split(',');
        //     var treeArray = treeStringArray.Select(s => int.TryParse(s, out var v) ? (int?)v : null).ToArray();

        //     Node root = treeArray.Length > 0 ? treeArray[0] == null ?
        //                 null :
        //                 new Node((int)treeArray[0]) : null;

        //     if (root == null)
        //         return null;

        //     Node left = treeArray.Length > 1 ?
        //                 treeArray[1] == null ? null : new Node((int)treeArray[1])
        //                 : null;

        //     Node right = treeArray.Length > 2 ?
        //                 treeArray[2] == null ? null : new Node((int)treeArray[2])
        //                 : null;

        //     if (treeArray.Length > 1) root.Left = left;
        //     if (treeArray.Length > 2) root.Right = right;


        //     int pParent = 1;
        //     int pLeft = 3;
        //     int pRight = 4;

        //     Node p = left;
        //     bool nextParentIsLeft = true;

        //     while (true)
        //     {
        //         if (pLeft < treeArray.Length)
        //         {
        //             var l = treeArray[pLeft] == null? null:  new Node(treeArray[pLeft].Value);
        //             p.Left = l;
        //         }

        //         if (pRight < treeArray.Length)
        //         {
        //             var r = treeArray[pRight] == null? null: new Node( treeArray[pRight].Value);
        //             p.Right = r;
        //         }

        //         pLeft += 2;
        //         pRight += 2;

        //         if (pLeft > treeArray.Length)
        //             break;

        //         p = nextParentIsLeft?p.Left:p.Right;
        //         nextParentIsLeft = !nextParentIsLeft;
        //     }

        //     return root;
        // }
    }

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