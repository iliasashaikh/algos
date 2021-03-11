using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Fb
{
    public class VerticalTraversal
    {
        // -2 -1 0 1 2
        public List<List<int>> VerticalOrder(TreeNode root)
        {
            Dictionary<int, List<TreeNode>> columnMap = new Dictionary<int, List<TreeNode>>();
            int minLevel = int.MaxValue;
            int maxLevel = int.MinValue;

            void Walk(TreeNode node, int level)
            {
                if (node == null)
                    return;

                minLevel = Math.Min(minLevel, level);
                maxLevel = Math.Min(maxLevel, level);
                var levelList = columnMap.TryGetValue(level, out var lst) ? lst : new List<TreeNode>();
                columnMap[level] = levelList;

                levelList.Add(node);
                Walk(node.Left, --level);
                Walk(node.Right, ++level);
            }

            int levelindex = 0;
            var lists = new List<List<int>>();

            for (int i = minLevel; i <= maxLevel; i++)
            {
                lists[levelindex] = columnMap.TryGetValue(i, out var lst) ? lst.Select(l=>l.Value).ToList(): null;
                levelindex++;
            }

            return lists;

        }
    }
}
