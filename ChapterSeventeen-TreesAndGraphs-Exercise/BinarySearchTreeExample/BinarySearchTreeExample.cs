using System;

namespace BinarySearchTreeExample
{
    class BinarySearchTreeExample
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<string>();
            tree.Insert("Software University");
            tree.Insert("Google");
            tree.Insert("Microsoft");
            tree.PrintTreeDFS();

            Console.WriteLine(tree.Contains("Google"));
            Console.WriteLine(tree.Contains("IBM"));
            tree.Remove("Google");
            Console.WriteLine(tree.Contains("Google"));
            tree.PrintTreeDFS();
        }
    }
}
