using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.HappySubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] sequence = new int[] { 1, 1, 2, 1, -1, 2, 3, -1, 1, 2, 3, 5, 1, -1, 2, 3 };

            var result = FindHappySubsequences(n, sequence);

            foreach (var item in result.OrderByDescending(x => x.Count).Take(10))
            {
                Console.WriteLine(String.Join(',', item));
            }
        }

        static List<List<int>> FindHappySubsequences(int n, int[] sequence)
        {
            var result = new List<List<int>>();

            for (int i = 0; i < sequence.Length; i++)
            {
                var list = new List<int>();

                for (int j = i; j < sequence.Length; j++)
                {
                    list.Add(sequence[j]);

                    if (list.Sum() == n)
                    {
                        result.Add(new List<int>(list));
                    }
                }
            }

            return result;
        }
    }
}
