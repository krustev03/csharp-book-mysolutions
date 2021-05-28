using System;
using System.Collections.Generic;

namespace _16.NTasks
{
    class Program
    {
        public class Edge
        {
            private int from;
            private int to;
            private int weight;

            public Edge(int f, int t, int w)
            {
                from = f;
                to = t;
                weight = w;
            }

            public int From
            {
                get => this.from;
                set => this.from = value;
            }

            public int To
            {
                get => this.to;
                set => this.to = value;
            }

            public int Weight
            {
                get => this.weight;
                set => this.weight = value;
            }
        }

        static void Main(string[] args)
        {
            int n = 6;
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < n; i++) graph.Add(i, new List<Edge>());
            graph[1].Add(new Edge(1, 2, 3));
            graph[2].Add(new Edge(2, 5, 2));
            graph[2].Add(new Edge(2, 4, 3));
            graph[3].Add(new Edge(3, 1, 1));

            int[] ordering = TopologicalSort(graph, n);

            Console.WriteLine(String.Join(' ', ordering));
        }

        private static int DFS(int i, int at, bool[] visited, int[] ordering, Dictionary<int, List<Edge>> graph)
        {

            visited[at] = true;

            List<Edge> edges = graph[at];

            if (edges != null)
            {
                foreach (Edge edge in edges)
                {
                    if (!visited[edge.To])
                    {
                        i = DFS(i, edge.To, visited, ordering, graph);
                    }
                }
            }

            ordering[i] = at;
            return i - 1;
        }

        public static int[] TopologicalSort(Dictionary<int, List<Edge>> graph, int numNodes)
        {
            int[] ordering = new int[numNodes];
            bool[] visited = new bool[numNodes];

            int i = numNodes - 1;
            for (int at = 0; at < numNodes; at++)
            {
                if (!visited[at])
                {
                    i = DFS(i, at, visited, ordering, graph);
                }
            }

            return ordering;
        }
    }
}
