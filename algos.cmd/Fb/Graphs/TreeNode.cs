using System.Collections.Generic;
using System.Linq;

namespace algos.Fb
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode Left { get => left; set => left = value; }

        public TreeNode Right { get => right; set => right = value; }
        public int Value { get => val; set => val = value; }

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
                    var l = treeArray[nextLeft] == null ? null : new TreeNode(treeArray[nextLeft].Value);
                    nextLeft += 2;
                    nextRoot.Left = l;
                    q.Enqueue(l);
                }

                if (nextRight < treeArray.Length)
                {
                    var r = treeArray[nextRight] == null ? null : new TreeNode(treeArray[nextRight].Value);
                    nextRight += 2;
                    nextRoot.Right = r;
                    q.Enqueue(r);
                }
            }

            return root;
        }
    }
}