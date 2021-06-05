using System;
using System.Collections.Generic;

namespace _08.AllSubsetsWithSumN
{
    class Program
    {
        static int k;
        static int n;
        static List<int> set = new List<int>();
        static int[] loops;
        static int[] checker;
        static int counter = 0;

        static void Main(string[] args)
        {
            Console.Write("N = ");
            n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            while (input != "")
            {
                set.Add(Convert.ToInt32(input));
                input = Console.ReadLine();
            }

            loops = new int[set.Count];

            if (set.Count == 0)
            {
                Console.Write("()");
            }

            for (int i = 1; i <= set.Count; i++)
            {
                k = i;
                checker = new int[k];

                GenerateSubsets(0);
            }

            if (counter > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                Console.WriteLine(" ");
            }
        }

        static void GenerateSubsets(int currentLoop)
        {
            if (currentLoop == set.Count)
            {
                if (AreDistinct(loops) && ValidSum(loops))
                {
                    PrintLoops();
                }

                return;
            }

            for (int i = 1; i <= set.Count; i++)
            {
                loops[currentLoop] = i;
                GenerateSubsets(currentLoop + 1);
            }
        }

        static void PrintLoops()
        {
            if (!CheckIfPrinted(loops))
            {
                counter++;
                Console.Write("(");
                for (int i = 0; i < k; i++)
                {
                    if (i == k - 1)
                    {
                        Console.Write(set[loops[i] - 1]);
                    }
                    else
                    {
                        Console.Write(set[loops[i] - 1] + " ");
                    }

                    checker[i] = loops[i];
                }
            
                Console.Write("), ");
            }
        }

        public static bool AreDistinct(int[] arr)
        {
            for (int i = 1; i < k; i++)
            {
                if (arr[i] <= arr[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidSum(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += set[arr[i] - 1];
            }

            if (sum != n)
            {
                return false;
            }

            return true;
        }

        static bool CheckIfPrinted(int[] arr)
        {
            for (int i = 0; i < k; i++)
            {
                if (checker[i] != loops[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
