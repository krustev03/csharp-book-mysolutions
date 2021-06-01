using System;
using System.Collections.Generic;

namespace _09.QueueSequenceOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int index = 0;

            while(queue.Count > 0)
            {
                index++;
                int current = queue.Dequeue();
                Console.WriteLine(" " + current);

                if (index == 50)
                {
                    return;
                }

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
