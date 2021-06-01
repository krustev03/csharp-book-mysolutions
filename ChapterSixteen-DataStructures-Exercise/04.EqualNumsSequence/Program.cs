using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EqualNumsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            Console.Write("Count of nums: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                list.Add(num);
            }

            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in list.OrderBy(x => x))
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    dic[item]++;
                }
            }

            var maxSeqPair = dic.OrderByDescending(x => x.Value).FirstOrDefault();
            var maxSeqNum = maxSeqPair.Key;
            int maxSeqCount = maxSeqPair.Value;

            var result = new List<int>();

            for (int i = 0; i < maxSeqCount; i++)
            {
                result.Add(maxSeqNum);
                Console.Write(maxSeqNum + " ");
            }
        }
    }
}
