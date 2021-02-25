/*
Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
*/

using NUnit.Framework;

namespace algos.Fb
{


    [TestFixture]
    public class ValidateBst
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

        public static bool IsBinarySearchTree(BinaryTreeNode root)
        {
            // Determine if the tree is a valid binary search tree


            return false;
        }

        [Test]
        public void ValidFullTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        [Test]
        public void BothSubtreesValidTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(20);
            a.InsertRight(60);
            var b = root.InsertRight(80);
            b.InsertLeft(70);
            b.InsertRight(90);
            var result = IsBinarySearchTree(root);
            Assert.False(result);
        }

        [Test]
        public void DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20).InsertLeft(10);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        [Test]
        public void OutOfOrderLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(70).InsertRight(60).InsertRight(80);
            var result = IsBinarySearchTree(root);
            Assert.False(result);
        }

        [Test]
        public void OneNodeTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }
    }
}