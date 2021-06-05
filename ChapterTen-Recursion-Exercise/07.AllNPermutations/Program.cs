using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AllNPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            RecursiveLoops(0);
        }

        static int n = 3;
        static int counter = 0;
        static int[] loops = new int[n];

        static void RecursiveLoops(int currentLoop)
        {
            if (currentLoop == n)
            {
                if (AreDistinct(loops))
                {
                    counter++;
                    PrintLoops();
                }

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
            Console.Write("(");
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Console.Write(loops[i]);
                }
                else
                {
                    Console.Write(loops[i] + " ");
                }
            }

            if (counter == CountSubsets())
            {
                Console.Write(")");
            }
            else
            {
                Console.Write("), ");
            }
        }

        static int CountSubsets()
        {
            int result = 1;
            for (int i = n; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }

        public static bool AreDistinct(int[] arr)
        {
            List<int> list = new List<int>(arr);
            for (int i = 0; i < n; i++)
            {
                if (list.FindAll(x => x == arr[i]).Count > 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
