/*

Write a method to see if a binary tree ↴ is "superbalanced" (a new tree property we just made up).

A tree is "superbalanced" if the difference between the depths of any two leaf nodes ↴ is no greater than one.

Here's a sample binary tree node class:

  public class BinaryTreeNode
{
    public int Value { get; }

    public BinaryTreeNode Left { get; private set; }

    public BinaryTreeNode Right { get; private set; }

    public BinaryTreeNode(int value)
    {
        Value = value;
    }

    public BinaryTreeNode InsertLeft(int leftValue)
    {
        Left = new BinaryTreeNode(leftValue);
        return Left;
    }

    public BinaryTreeNode InsertRight(int rightValue)
    {
        Right = new BinaryTreeNode(rightValue);
        return Right;
    }
}
*/

using NUnit.Framework;

namespace algos.Fb
{


    [TestFixture]
    public class BalancedBinaryTree
    {
        public class BinaryTreeNode
        {
            public int Value { get; }
            public BinaryTreeNode Left { get; private set; }
            public BinaryTreeNode Right { get; private set; }

            public BinaryTreeNode(int value)
            {
                Value = value;
            }

            public BinaryTreeNode InsertLeft(int leftValue)
            {
                Left = new BinaryTreeNode(leftValue);
                return Left;
            }

            public BinaryTreeNode InsertRight(int rightValue)
            {
                Right = new BinaryTreeNode(rightValue);
                return Right;
            }
        }

        public static bool IsBalanced(BinaryTreeNode treeRoot)
        {
            // Determine if the tree is superbalanced


            return false;
        }
        // Tests

        [Test]
        public void FullTreeTest()
        {
            var root = new BinaryTreeNode(5);
            var a = root.InsertLeft(8);
            var b = root.InsertRight(6);
            a.InsertLeft(1);
            a.InsertRight(2);
            b.InsertLeft(3);
            b.InsertRight(4);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Test]
        public void BothLeavesAtTheSameDepthTest()
        {
            var root = new BinaryTreeNode(3);
            root.InsertLeft(4).InsertLeft(1);
            root.InsertRight(2).InsertRight(9);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Test]
        public void LeafHeightsDifferByOneTest()
        {
            var root = new BinaryTreeNode(6);
            root.InsertLeft(1);
            root.InsertRight(0).InsertRight(7);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Test]
        public void LeafHeightsDifferByTwoTest()
        {
            var root = new BinaryTreeNode(6);
            root.InsertLeft(1);
            root.InsertRight(0).InsertRight(7).InsertRight(8);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Test]
        public void ThreeLeavesTotalTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertLeft(5);
            var a = root.InsertRight(9);
            a.InsertLeft(8);
            a.InsertRight(5);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Test]
        public void BothSubTreesSuperbalancedTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertLeft(5);
            var b = root.InsertRight(9);
            b.InsertLeft(8).InsertLeft(7);
            b.InsertRight(5);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Test]
        public void BothSubTreesSuperbalancedTwoTest()
        {
            var root = new BinaryTreeNode(1);
            var a = root.InsertLeft(2);
            var b = root.InsertRight(4);
            a.InsertLeft(3);
            a.InsertRight(7).InsertRight(8);
            b.InsertRight(5).InsertRight(6).InsertRight(9);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Test]
        public void ThreeLeavesAtDifferentLevelsTest()
        {
            var root = new BinaryTreeNode(1);
            var a = root.InsertLeft(2);
            var b = a.InsertLeft(3);
            a.InsertRight(4);
            b.InsertLeft(5);
            b.InsertRight(6);
            root.InsertRight(7).InsertRight(8).InsertRight(9).InsertRight(10);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Test]
        public void OnlyOneNodeTest()
        {
            var root = new BinaryTreeNode(1);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Test]
        public void TreeIsLinkedListTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertRight(2).InsertRight(3).InsertRight(4);
            var result = IsBalanced(root);
            Assert.True(result);
        }
    }
}