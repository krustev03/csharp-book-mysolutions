using System;

namespace _01.AllKVariations
{
    class Program
    {
        static void Main(string[] args)
        {
            RecursiveLoops(0);
        }

        static int n = 3;
        static int k = 2;
        static int index = 1;
        static int[] loops = new int[k];

        static void RecursiveLoops(int currentLoop)
        {
            if (currentLoop == n)
            {
                PrintLoops(currentLoop);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                loops[currentLoop] = i;
                RecursiveLoops(currentLoop + 1);
            }
        }

        static void PrintLoops(int currentLoop)
        {
            Console.Write("(");
            for (int i = 0; i < k; i++)
            {
                if (i == k - 1)
                {
                    Console.Write(loops[i]);
                }
                else
                {
                    Console.Write(loops[i] + " ");
                }
            }
            if (currentLoop == k && index == n)
            {
                Console.Write(")");
            }
            else
            {
                Console.Write("), ");
            }
        }
    }
}
