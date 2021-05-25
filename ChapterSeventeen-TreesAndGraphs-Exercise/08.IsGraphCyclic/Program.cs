using System;
using System.Collections.Generic;

namespace _08.IsGraphCyclic
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
            int n = 7;
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < n; i++) 
            {
                graph.Add(i, new List<Edge>());
            }

            // Cyclic
            graph[0].Add(new Edge(0, 1, 3));
            graph[0].Add(new Edge(0, 5, 3));
            graph[1].Add(new Edge(1, 3, 1));
            graph[1].Add(new Edge(1, 2, 6));
            graph[2].Add(new Edge(2, 0, 1));
            graph[2].Add(new Edge(2, 3, 1));
            graph[2].Add(new Edge(2, 4, 10));
            graph[3].Add(new Edge(3, 4, 5));
            graph[5].Add(new Edge(5, 4, 7));

            // Acyclic
            //graph[0].Add(new Edge(0, 1, 3));
            //graph[0].Add(new Edge(0, 2, 2));
            //graph[0].Add(new Edge(0, 5, 3));
            //graph[1].Add(new Edge(1, 3, 1));
            //graph[1].Add(new Edge(1, 2, 6));
            //graph[2].Add(new Edge(2, 3, 1));
            //graph[2].Add(new Edge(2, 4, 10));
            //graph[3].Add(new Edge(3, 4, 5));
            //graph[5].Add(new Edge(5, 4, 7));

            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Stack<int> visitedOneSearch = new Stack<int>();
                    DFS(graph, visited, i, visitedOneSearch);

                    if (isCyclic)
                    {
                        Console.Write("The graph has a cycle which is: ");

                        foreach (var item in visitedOneSearch)
                        {
                            Console.Write(item + " ");
                        }

                        return;
                    }
                }
            }

            Console.WriteLine("The graph is acyclic.");
        }

        static bool isCyclic;

        private static void DFS(Dictionary<int, List<Edge>> graph, bool[] visited, int v, Stack<int> visitedOneSearch)
        {
            visited[v] = true;
            visitedOneSearch.Push(v);
            List<Edge> edges = graph[v];

            if (edges != null)
            {
                foreach (Edge edge in edges)
                {
                    if (!visited[edge.To])
                    {
                        DFS(graph, visited, edge.To, visitedOneSearch);

                        if (isCyclic)
                        {
                            return;
                        }
                    }
                    else if (visitedOneSearch.Contains(edge.To))
                    {
                        isCyclic = true;
                        return;
                    }
                }
            }

            visitedOneSearch.Pop();
        }
    }
}
