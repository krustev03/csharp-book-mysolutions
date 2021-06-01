using System;
using System.Collections.Generic;

namespace _07.CountOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[1001];

            Console.Write("Count of nums: ");
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                nums[i] = num;

                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 1);
                }
                else
                {
                    dic[num]++;
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"Number {item.Key} - {item.Value} times");
            }
        }
    }
}
