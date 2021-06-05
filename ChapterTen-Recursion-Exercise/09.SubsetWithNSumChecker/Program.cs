using System;
using System.Collections.Generic;

namespace _09.SubsetWithNSumChecker
{
    class Program
    {
        static int k;
        static int n;
        static List<int> set = new List<int>();
        static int[] loops;
        static bool hasSubset = false;

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

            for (int i = 1; i <= set.Count; i++)
            {
                k = i;

                GenerateSubsets(0);

                if (hasSubset)
                {
                    Console.WriteLine("Subset with N sum exists.");
                    return;
                }
            }

            Console.WriteLine("No subset with sum = N found.");
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
            hasSubset = true;
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
    }
}
