using System;

namespace _01.FindNumMatches
{
    public class Tree<T>
    {
        private TreeNode<int> root;

        public Tree(int value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = new TreeNode<int>(value);
        }

        public Tree(int value, params Tree<int>[] children)
            : this(value)
        {
            foreach (Tree<int> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<int> Root => this.root;

        private int count = 0;
        private void CountNumInTree(TreeNode<int> root, string spaces, int numToCount)
        {
            if (this.root == null)
            {
                return;
            }

            if (root.Value == numToCount)
            {
                count++;
            }

            TreeNode<int> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                CountNumInTree(child, spaces + "   ", numToCount);
            }
        }

        public void CountNumInTree(int numToCount) 
        {
            this.CountNumInTree(this.root, string.Empty, numToCount);
            Console.WriteLine($"The count of {numToCount} in the tree is {count}");
            count = 0;
        }
    }
}
