using System;
using System.Collections.Generic;

namespace _04.StringSet
{
    class Program
    {
        static int k = 2, counter = 0;
        static List<string> set = new List<string>();
        static int[] loops;
        static int[] checker = new int[k];

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "")
            {
                set.Add(input);
                input = Console.ReadLine();
            }

            loops = new int[set.Count];

            if (k > set.Count)
            {
                Console.WriteLine("K is more than all elements.");
            }
            else
            {
                GenerateSubsets(0);
            }
        }

        static void GenerateSubsets(int currentLoop)
        {
            if (currentLoop == set.Count)
            {
                if (AreDistinct(loops))
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
                if (counter == CountSubsets())
                {
                    Console.Write(")");
                }
                else
                {
                    Console.Write("), ");
                }
            }
        }

        static int CountSubsets()
        {
            int first = 1;
            for (int i = loops.Length; i >= loops.Length - k + 1; i--)
            {
                first *= i;
            }

            int second = 1;
            for (int i = k; i > 0; i--)
            {
                second *= i;
            }

            return first / second;
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
