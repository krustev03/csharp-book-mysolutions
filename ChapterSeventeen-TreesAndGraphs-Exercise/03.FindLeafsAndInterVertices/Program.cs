// Leaves* (didn't get enough sleep)
namespace _03.FindLeafsAndInterVertices
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
                 new Tree<int>(21),
                 new Tree<int>(14,
                   new Tree<int>(23),
                   new Tree<int>(6))
               );

            tree.PrintLeavesAndInternalVerticesCount();
        }
    }
}
