using System;
using System.Collections.Generic;

namespace _01.CountOfOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();

            CountOccurences(arr, dic);

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
        }

        static void CountOccurences(int[] arr, SortedDictionary<int, int> dic)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if  (!dic.ContainsKey(arr[i]))
                {
                    dic.Add(arr[i], 1);
                }
                else
                {
                    dic[arr[i]]++;
                }
            }
        }
    }
}
