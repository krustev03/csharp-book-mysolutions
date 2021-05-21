using System;

namespace BinaryTreeExample
{
    /// <summary> Demonstrates how the BinaryTree<T> class can be used </summary>
    class BinaryTreeExample
    {
        static void Main(string[] args)
        {
            // Create the binary tree from the sample
            BinaryTree<int> binaryTree = new BinaryTree<int>(14,
               new BinaryTree<int>(19,
                 new BinaryTree<int>(23),
                 new BinaryTree<int>(6,
                   new BinaryTree<int>(10),
                   new BinaryTree<int>(21))),
               new BinaryTree<int>(15,
                 new BinaryTree<int>(3),
                 null));

            // Traverse and print the tree in in-order manner
            binaryTree.PrintInOrder();
            Console.WriteLine();

            // Traverse and print the tree in pre-order manner
            binaryTree.PrintPreOrder();
            Console.WriteLine();

            // Traverse and print the tree in post-order manner
            binaryTree.PrintPostOrder();
        }
    }
}
