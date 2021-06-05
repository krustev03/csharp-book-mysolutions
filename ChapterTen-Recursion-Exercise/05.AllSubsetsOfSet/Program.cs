using System;
using System.Collections.Generic;

namespace _05.AllSubsetsOfSet
{
    class Program
    {
        static int k, counter;
        static List<string> set = new List<string>();
        static int[] loops;
        static int[] checker;
        static bool finalIteration;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "")
            {
                set.Add(input);
                input = Console.ReadLine();
            }

            loops = new int[set.Count];

            if (set.Count == 0)
            {
                Console.Write("()");
            }
            else
            {
                Console.Write("(), ");
            }

            for (int i = 1; i <= set.Count; i++)
            {
                k = i;
                checker = new int[k];
                counter = 0;
                
                if (i == set.Count)
                {
                    finalIteration = true;
                }

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
                if (CountSubsets() == counter && finalIteration)
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
