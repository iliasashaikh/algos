using System.Collections.Generic;
using System.Linq;

namespace algos.Fb
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Value { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            var q = new Queue<TreeNode>();
            var l = new List<TreeNode>();
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

        public static TreeNode FromString(string treeString)
        {
            var q = new Queue<TreeNode>();
            var treeStringArray = treeString.Split(',');
            var treeArray = treeStringArray.Select(s => int.TryParse(s, out var v) ? (int?)v : null).ToArray();

            var root = new TreeNode(treeArray[0].Value);
            int nextLeft = 1;
            int nextRight = 2;

            var nextRoot = root;
            q.Enqueue(nextRoot);
            while (q.TryPeek(out _))
            {
                nextRoot = q.Dequeue();

                if (nextLeft < treeArray.Length)
                {
                    var l = treeArray[nextLeft] == null? null: new TreeNode(treeArray[nextLeft].Value);
                    nextLeft += 2;
                    nextRoot.Left = l;
                    q.Enqueue(l);
                }

                if (nextRight < treeArray.Length)
                {
                    var r = treeArray[nextRight] ==null? null: new TreeNode(treeArray[nextRight].Value);
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
}