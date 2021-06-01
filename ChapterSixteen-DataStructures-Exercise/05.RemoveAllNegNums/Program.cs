using System;
using System.Collections.Generic;

namespace _05.RemoveAllNegNums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            string input = Console.ReadLine();
            while (input.Trim() != "")
            {
                list.Add(Convert.ToInt32(input));
                input = Console.ReadLine();
            }

            var positiveList = new List<int>();

            foreach (var item in list)
            {
                if (item > -1)
                {
                    positiveList.Add(item);
                }
            }

            foreach (var item in positiveList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
