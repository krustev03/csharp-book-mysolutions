using System;
using System.Collections.Generic;

namespace Fourth
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split("\\");
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
