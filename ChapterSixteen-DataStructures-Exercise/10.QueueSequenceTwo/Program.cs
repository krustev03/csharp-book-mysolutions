using System;
using System.Collections.Generic;

namespace _10.QueueSequenceTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("M: ");
            int m = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int index = 0;

            while (queue.Count > 0)
            {
                index++;
                int current = queue.Dequeue();
                Console.WriteLine(" " + current);

                if (current == m)
                {
                    return;
                }

                var first = current + 1;
                var second = first + 2;
                var third = second * 2;

                queue.Enqueue(first);
                queue.Enqueue(second);
                queue.Enqueue(third);
            }
        }
    }
}
