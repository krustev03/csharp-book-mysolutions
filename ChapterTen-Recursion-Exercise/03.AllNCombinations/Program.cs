using System;

namespace _03.AllNCombinations
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
        static bool isLast = false;
        static int[] loops = new int[k];

        static void RecursiveLoops(int currentLoop)
        {
            if (currentLoop == k)
            {
                PrintLoops();
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                loops[currentLoop] = i;
                if (currentLoop == k - 1 && index == n && i == n)
                {
                    isLast = true;
                }
                RecursiveLoops(currentLoop + 1);
            }

            index++;
        }

        static void PrintLoops()
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
            if (isLast)
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
