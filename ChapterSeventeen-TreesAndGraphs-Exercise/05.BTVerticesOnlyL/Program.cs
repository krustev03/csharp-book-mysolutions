namespace _05.BTVerticesOnlyL
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(14,
               new BinaryTree<int>(19,
                 new BinaryTree<int>(23,
                   null,
                   new BinaryTree<int>(111)),
                 new BinaryTree<int>(6,
                   new BinaryTree<int>(10),
                   new BinaryTree<int>(21))),
               new BinaryTree<int>(15,
                 new BinaryTree<int>(3),
                 null));

            binaryTree.PrintVerticesWhoOnlyHaveLeaves();
        }
    }
}
