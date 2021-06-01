using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.AscendingOrder
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

            foreach (var item in list.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }
        }
    }
}
