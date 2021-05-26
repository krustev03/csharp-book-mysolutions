using System;
using System.Collections.Generic;

namespace _09.JustDFS
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
            // Expected Output: [0, 4, 1, 2, 6, 3, 5]
            for (int i = 0; i < graph.Size; i++)
            {
                if (!visited[i])
                {
                    DFS(i);
                }
            }
        }

        static bool[] visited = new bool[graph.Size];

        static void DFS(int v)
        {
            visited[v] = true;
            Console.Write(v + " ");

            var children = graph.GetSuccessors(v);

            foreach (var child in children)
            {
                if (!visited[child])
                {
                    visited[child] = true;
                    DFS(child);
                }
            }
        }
    }
}
