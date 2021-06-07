using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddTimesNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6};

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dic.ContainsKey(arr[i]))
                {
                    dic.Add(arr[i], 1);
                }
                else
                {
                    dic[arr[i]]++;
                }
            }

            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dic[arr[i]] % 2 == 0)
                {
                    result.Add(arr[i]);
                }
            }

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}
