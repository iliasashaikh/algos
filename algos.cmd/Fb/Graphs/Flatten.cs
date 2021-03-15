using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.Graphs
{
    public class Flatten
    {
        List<TreeNode> nodes = new List<TreeNode>();
        public TreeNode Run(TreeNode root)
        {
            void Walk(TreeNode node)
            {
                if (node == null)
                    return;

                nodes.Add(node);
                Walk(root.left);
                Walk(root.right);
            }

            Walk(root);
            TreeNode preHead = new TreeNode(-1);
            var current = preHead;
            for (int i = 0; i < nodes.Count; i++)
            {
                current.left = null;
                current.right = nodes[i];
            }

            return preHead.right;

        }

    }
}
