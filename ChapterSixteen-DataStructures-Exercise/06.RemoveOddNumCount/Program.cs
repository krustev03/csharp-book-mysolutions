using System;
using System.Collections.Generic;

namespace _06.RemoveOddNumCount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            string input = Console.ReadLine();
            while (input.Trim() != "")
            {
                var inputAsInt = Convert.ToInt32(input);

                list.Add(inputAsInt);

                if (!dic.ContainsKey(inputAsInt))
                {
                    dic.Add(inputAsInt, 1);
                }
                else
                {
                    dic[inputAsInt]++;
                }

                input = Console.ReadLine();
            }

            foreach (var item in dic)
            {
                if (item.Value % 2 != 0)
                {
                    list.RemoveAll(x => x == item.Key);
                }
            }

            Console.WriteLine("Result:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
