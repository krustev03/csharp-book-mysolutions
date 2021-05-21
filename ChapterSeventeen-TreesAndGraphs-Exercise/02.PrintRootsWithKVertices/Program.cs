using System;

namespace _02.PrintRootsWithKVertices
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree =
                new Tree<int>(7,
                  new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                  new Tree<int>(21,
                    new Tree<int>(111)),
                  new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6))
                );

            Console.Write("Number of vertices: ");
            int k = int.Parse(Console.ReadLine());

            if (k == 1)
            {
                Console.Write(tree.Root.Value + " ");
            }

            tree.PrintRootsWithKVertices(k);
        }
    }
}
