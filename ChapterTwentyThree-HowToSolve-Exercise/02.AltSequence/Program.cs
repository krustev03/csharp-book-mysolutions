using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AltSequence
{
    class Program
    {
        static HashSet<int> set = new HashSet<int>() { 2, 5, 3, 4 };
        static Stack<int> stack = new Stack<int>();
        static Dictionary<int, List<int>> visited = new Dictionary<int, List<int>>();
        static int k = 3;
        static int currIndex = 1;
        static int smallerNum = 0;
        static int biggerNum = 0;
        static bool isSearchingSmaller = true;

        static void Main(string[] args)
        {
            if (k == 0)
            {
                Console.WriteLine("{}");
            }
            else if (k > set.Count)
            {
                Console.WriteLine("K is more than N");
            }
            else
            {
                foreach (var item in set.OrderBy(x => x))
                {
                    stack = new Stack<int>();
                    visited = new Dictionary<int, List<int>>();
                    currIndex = 1;

                    PrintAlternativeSequences(item);
                }
            }
        }

        static void PrintAlternativeSequences(int num)
        {
            stack.Push(num);

            for (int i = 0; i < k + 1; i++)
            {
                visited.Add(i, new List<int>());
            }

            while (stack.Count > 0)
            {
                if (stack.Count < k)
                {
                    num = stack.Peek();

                    FindSearchingStatement(num);

                    if (isSearchingSmaller && FindSmallerNum(num))
                    {
                        int element = smallerNum;
                        stack.Push(element);
                        currIndex++;
                        continue;
                    }
                    if (isSearchingSmaller == false && FindBiggerNum(num))
                    {
                        int element = biggerNum;
                        stack.Push(element);
                        currIndex++;
                        continue;
                    }

                    GoDownLevel();
                }
                else
                {
                    PrintSubset();
                    GoDownLevel();
                }
            }
        }

        static bool FindSmallerNum(int num)
        {
            int max = int.MinValue;
            bool exists = false;

            foreach (var element in set)
            {
                if (!visited[currIndex].Contains(element) && !stack.Contains(element))
                {
                    if (element - num < 0 && Math.Abs(element - num) > max)
                    {
                        max = Math.Abs(element - num);
                        smallerNum = element;
                        exists = true;
                    }
                }
            }

            return exists;
        }

        static bool FindBiggerNum(int num)
        {
            int min = int.MaxValue;
            bool exists = false;

            foreach (var element in set)
            {
                if (!visited[currIndex].Contains(element) && !stack.Contains(element))
                {
                    if (element - num > 0 && Math.Abs(element - num) < min)
                    {
                        min = Math.Abs(element - num);
                        biggerNum = element;
                        exists = true;
                    }
                }
            }

            return exists;
        }

        static void FindSearchingStatement(int num)
        {
            isSearchingSmaller = false;

            if (stack.Count == 1)
            {
                foreach (var item in set)
                {
                    if (item < num && visited[currIndex].Contains(item) == false)
                    {
                        isSearchingSmaller = true;
                    }
                }
            }

            else
            {
                var list = new List<int>(stack);
                if (list[0] > list[1])
                {
                    isSearchingSmaller = true;
                }
            }
        }

        static void PrintSubset()
        {
            var reversedStack = stack.Reverse();
            Console.Write("{" + String.Join(',', reversedStack) + "} ");
        }

        static void GoDownLevel()
        {
            currIndex--;
            visited[currIndex + 1] = new List<int>();
            visited[currIndex].Add(stack.Pop());
        }
    }
}
