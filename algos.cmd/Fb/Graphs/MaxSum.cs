using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace algos.Fb.Graphs
{
    [TestFixture]
    public class MaxSum
    {
        int maxSum = int.MinValue;
        public int MaxPathSumR(TreeNode root)
        {

            Console.Write(root?.val.ToString() ?? "null");

            if (root == null)
                return 0;


            var leftSum = MaxPathSumR(root.left);
            var rightSum = MaxPathSumR(root.right);

            var sum1 = root.val + leftSum + rightSum;
            maxSum = Max(sum1, maxSum);

            var r = Max(leftSum, rightSum);
            var sum2 = root.val + r;
            maxSum = Max(sum2, maxSum);

            maxSum = Max(root.val, maxSum);


            if (r < 0)
                return root.val;
            else
                return root.val + r;
        }

        public int MaxPathSum(TreeNode root)
        {
            MaxPathSumR(root);

            return maxSum;
        }

        [Test]
        public void Test()
        {
            var node = TreeNode.FromString("1,2,3");
            
        }
    }
}
