/*

Validate Binary Search Tree

Solution

Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.

https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/266/
*/

public class ValidateBst
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public bool IsValidBST(TreeNode root)
    {
        // traverse the tree 'In order'
        // node must be greater than previous node

        if (root == null)
            return false;

        if (root.left == null && root.right == null)
            return true;


        long previous = long.MinValue;
        bool isBst = true;
        void WalkTree(TreeNode n)
        {
            if (n == null)
                return;

            WalkTree(n.left);

            if (n.val <= previous)
                isBst = false;

            previous = n.val;

            WalkTree(n.right);

        }

        WalkTree(root);
        return isBst;

    }


}
