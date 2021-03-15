using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algos.Fb.Graphs
{

    [TestFixture]
    public class TreePaths
    {
        List<string> paths = new List<string>();
        TreeNode root = null;

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            this.root = root;
            MakePath("",root);
            return paths;
        }


        void MakePath(string path, TreeNode node)
        {
            if (node == null)
                return;

            path += node.val;
            if (node.left == null && node.right == null)
            {
                paths.Add(path);
            }
            MakePath(path + "->", node.left);
            MakePath(path + "->", node.right);
        }

        [Test]
        public void Test()
        {
            var tree = TreeNode.FromString("1,2,3");
            var paths = BinaryTreePaths(tree);

            Assert.AreEqual(2, paths.Count);
        }
    }
}
