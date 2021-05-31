using System;
using System.Collections.Generic;

namespace _02.PrintInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            Console.Write("Count of nums: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                stack.Push(num);
            }

            Console.WriteLine("Nums in reverse order: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
