using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.JustBFS
{
    class Program
    {
       static Graph graph = new Graph(new List<int>[]
       {
            new List<int>() {4},
            new List<int>() {1, 2, 6},
            new List<int>() {1, 6},
            new List<int>() {6},
            new List<int>() {0},
            new List<int>() {},
            new List<int>() {1, 2, 3},
       });

        static void Main(string[] args)
        {
            // Expected output: [0, 4]
            BFS(0);
            // Expected output: [1, 2, 6, 3]
            BFS(1);
            // Expected output: [5]
            BFS(5);
        }

        static void BFS(int v)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);

            bool[] visited = new bool[graph.Size];
            visited[v] = true;

            while (queue.Any())
            {
                int node = queue.Dequeue();
                Console.Write(node + " ");

                var children = graph.GetSuccessors(node);

                foreach (var child in children)
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
