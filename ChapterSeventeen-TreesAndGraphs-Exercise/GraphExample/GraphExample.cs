using System;
using System.Collections.Generic;

namespace GraphExample
{
    public class GraphExample
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
            Console.WriteLine("Connected graph components: ");

            for (int v = 0; v < graph.Size; v++)
            {
                if (!visited[v])
                {
                    TraverseDFS(v);
                    Console.WriteLine();
                }
            }
        }

        static bool[] visited = new bool[graph.Size];

        static void TraverseDFS(int v)
        {
            if (!visited[v])
            {
                Console.Write(v + " ");
                visited[v] = true;

                foreach (int child in graph.GetSuccessors(v))
                {
                    TraverseDFS(child);
                }
            }
        }
    }
}
