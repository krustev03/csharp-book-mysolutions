using System;

namespace _02.NCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            RecursiveLoops(0);
        }

        static int n = 3;
        static int[] loops = new int[n];

        static void RecursiveLoops(int currentLoop)
        {
            if (currentLoop == n)
            {
                PrintLoops();
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                loops[currentLoop] = i;
                RecursiveLoops(currentLoop + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(loops[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
