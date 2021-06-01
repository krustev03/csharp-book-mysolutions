using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAndAverageList
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

            Console.WriteLine($"The sum is: {list.Sum()}");
            Console.WriteLine($"The average is: {list.Average()}");
        }
    }
}
