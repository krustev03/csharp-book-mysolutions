using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BalancedBTCheck
{
    /// <summary> Represents a binary tree node </summary>
    /// <typeparam name="T">the type of the values in the tree</typeparam>
    public class BinaryTree<T>
    {
        /// <summary> Constructs a binary tree </summary>
        /// <param name="value">the value of the tree</param>
        /// <param name="leftChild">the left child of the tree</param>
        /// <param name="rightChild">the right child of the tree</param>
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        /// <summary> Constructs a binary tree with no children </summary>
        /// <param name="value">the value of the tree</param>
        public BinaryTree(T value)
            : this(value, null, null)
        {
        }

        /// <summary> The value stored in the current node </summary>
        public T Value { get; set; }

        /// <summary> The left child of the current node </summary>
        public BinaryTree<T> LeftChild { get; set; }

        /// <summary> The right child of the current node </summary>
        public BinaryTree<T> RightChild { get; set; }

        public void PrintPreOrder()
        {
            // 1. Visit the root of this subtree
            Console.Write(this.Value + " ");

            // 2. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintPreOrder();
            }

            // 3. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintPreOrder();
            }
        }

        private IDictionary<int, List<string>> GetVerticesAtEveryLevel(int currLevel, Dictionary<int, List<string>> sumsOnLevels, BinaryTree<T> tree)
        {
            if (tree.LeftChild != null)
            {
                currLevel++;
                GetVerticesAtEveryLevel(currLevel, sumsOnLevels, tree.LeftChild);
                currLevel--;
            }

            if (tree.RightChild != null)
            {
                currLevel++;
                GetVerticesAtEveryLevel(currLevel, sumsOnLevels, tree.RightChild);
                currLevel--;
            }

            if (!sumsOnLevels.ContainsKey(currLevel))
            {
                sumsOnLevels.Add(currLevel, new List<string>());
            }

            sumsOnLevels[currLevel].Add(tree.Value.ToString());

            return sumsOnLevels;
        }

        public void BalanceChecker()
        {
            int currLevel = 0;

            var leftTree = this.LeftChild;
            var levelsLeft = new Dictionary<int, List<string>>();
            var resultLeft = GetVerticesAtEveryLevel(currLevel, levelsLeft, leftTree);

            Console.WriteLine();

            currLevel = 0;
            var rightTree = this.RightChild;
            var levelsRight = new Dictionary<int, List<string>>();
            var resultRight = GetVerticesAtEveryLevel(currLevel, levelsRight, rightTree);

            var lowestLevelLeft = resultLeft.OrderByDescending(x => x.Key).FirstOrDefault().Key;
            var lowestLevelRight = resultRight.OrderByDescending(x => x.Key).FirstOrDefault().Key;

            if (Math.Abs(lowestLevelLeft - lowestLevelRight) <= 1)
            {
                Console.WriteLine("The binary tree is balanced.");
            }
            else
            {
                Console.WriteLine("The binary tree is not balanced.");
            }
        }

        public void PrintPostOrder()
        {
            // 1. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintPostOrder();
            }

            // 2. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintPostOrder();
            }

            // 3. Visit the root of this subtree
            Console.Write(this.Value + " ");
        }
    }
}
