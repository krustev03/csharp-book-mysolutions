using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.BTVerticesSum
{
    public class BinaryTree<T>
    {
        public BinaryTree(int value, BinaryTree<int> leftChild, BinaryTree<int> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        /// <summary> Constructs a binary tree with no children </summary>
        /// <param name="value">the value of the tree</param>
        public BinaryTree(int value)
            : this(value, null, null)
        {
        }

        /// <summary> The value stored in the current node </summary>
        public int Value { get; set; }

        /// <summary> The left child of the current node </summary>
        public BinaryTree<int> LeftChild { get; set; }

        /// <summary> The right child of the current node </summary>
        public BinaryTree<int> RightChild { get; set; }

        private void GetVerticesSumAtEveryLevel(int currLevel, Dictionary<int, List<int>> sumsOnLevels)
        {
            // 1. Visit the left child
            if (this.LeftChild != null)
            {
                currLevel++;
                this.LeftChild.GetVerticesSumAtEveryLevel(currLevel, sumsOnLevels);
                currLevel--;
            }

            // 2. Visit the right child
            if (this.RightChild != null)
            {
                currLevel++;
                this.RightChild.GetVerticesSumAtEveryLevel(currLevel, sumsOnLevels);
                currLevel--;
            }

            if (!sumsOnLevels.ContainsKey(currLevel))
            {
                sumsOnLevels.Add(currLevel, new List<int>());
            }

            sumsOnLevels[currLevel].Add(this.Value);

            if (currLevel == 0)
            {
                foreach (var item in sumsOnLevels.OrderBy(x => x.Key))
                {
                    Console.Write("Level " + item.Key + ": ");
                    int sum = 0;
                    foreach (var num in item.Value)
                    {
                        sum += num;
                    }
                    Console.Write(sum);
                    Console.WriteLine();
                }
            }
        }

        public void PrintSumsOnLevels()
        {
            int currLevel = 0;
            var sumsOnlevels = new Dictionary<int, List<int>>();

            GetVerticesSumAtEveryLevel(currLevel, sumsOnlevels);
        } 
    }
}
