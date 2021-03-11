using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    [TestFixture]
    public class BinaryTreeLevelLists
    {
        public List<List<TreeNode>> MakeLevels(TreeNode root)
        {
            var currentLevel = new Queue<TreeNode>();
            var nextLevel = new Queue<TreeNode>();

            var allLevels = new List<List<TreeNode>>();
            nextLevel.Enqueue(root);

            var levels = new List<List<TreeNode>>();

            while (nextLevel.Count > 0)
            {
                currentLevel = nextLevel;
                nextLevel = new Queue<TreeNode>();

                var level = new List<TreeNode>();
                
                while (currentLevel.Count > 0)
                {
                    var n = currentLevel.Dequeue();
                    level.Add(n);
                    if (n.Left != null)
                        nextLevel.Enqueue(n.Left);
                    if (n.Right != null)
                        nextLevel.Enqueue(n.Right);
                }
                levels.Add(level);
            }

            return levels;
        }

        [Test]
        public void TestLevelsOfBT()
        {
            var tree = TreeNode.FromString("1,2,3,4,5,6,7,8");
            var levels = MakeLevels(tree);

            Assert.That(levels.Count, Is.EqualTo(4));
        }
    }
}
