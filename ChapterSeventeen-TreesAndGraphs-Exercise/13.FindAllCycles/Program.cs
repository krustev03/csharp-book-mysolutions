using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.FindAllCycles
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
            graph[1].Add(new Edge(1, 2, 3));
            graph[2].Add(new Edge(2, 0, 6));
            graph[2].Add(new Edge(2, 3, 1));
            graph[3].Add(new Edge(3, 4, 1));
            graph[4].Add(new Edge(4, 5, 10));
            graph[5].Add(new Edge(5, 6, 5));
            graph[6].Add(new Edge(6, 4, 5));

            // Cyclic
            //graph[0].Add(new Edge(0, 1, 3));
            //graph[0].Add(new Edge(0, 5, 3));
            //graph[1].Add(new Edge(1, 2, 6));
            //graph[2].Add(new Edge(2, 0, 1));
            //graph[2].Add(new Edge(2, 3, 1));
            //graph[2].Add(new Edge(2, 4, 10));
            //graph[3].Add(new Edge(3, 4, 5));
            //graph[3].Add(new Edge(3, 1, 5));
            //graph[5].Add(new Edge(5, 4, 7));
            //graph[5].Add(new Edge(5, 2, 7));

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
            Dictionary<int, List<int>> listOfCycles = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Stack<int> visitedOneSearch = new Stack<int>();
                    DFS(graph, visited, i, visitedOneSearch, listOfCycles);
                }
            }

            if (!isCyclic)
            {
                Console.WriteLine("The graph is acyclic.");
            }
            else
            {
                foreach (var cycle in listOfCycles)
                {
                    Console.Write($"Cycle {cycle.Key}: ");
                    foreach (var member in cycle.Value)
                    {
                        Console.Write(member + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static bool isCyclic;
        static int cycleNumber;

        private static void DFS(Dictionary<int, List<Edge>> graph, bool[] visited, int v, Stack<int> visitedOneSearch, Dictionary<int, List<int>> listOfCycles)
        {
            visited[v] = true;
            visitedOneSearch.Push(v);
            List<Edge> edges = graph[v];

            if (edges != null)
            {
                foreach (Edge edge in edges)
                {
                    if (!visitedOneSearch.Contains(edge.To))
                    {
                        DFS(graph, visited, edge.To, visitedOneSearch, listOfCycles);
                    }
                    else if (visitedOneSearch.Contains(edge.To))
                    {
                        isCyclic = true;
                        bool cycleBegin = false;

                        List<int> cycleMembers = new List<int>();

                        foreach (var item in visitedOneSearch.Reverse())
                        {
                            if (item == edge.To)
                            {
                                cycleBegin = true;
                            }

                            if (cycleBegin)
                            {
                                cycleMembers.Add(item);
                            }
                        }

                        int cyclesCount = listOfCycles.Keys.Count;
                        int countValidCycles = 0;
                        foreach (var cycle in listOfCycles.Keys)
                        {
                            foreach (var member in cycleMembers)
                            {
                                if (!listOfCycles[cycle].Contains(member))
                                {
                                    countValidCycles++;
                                    break;
                                }
                            }
                        }

                        if (cyclesCount == countValidCycles)
                        {
                            cycleNumber++;
                            listOfCycles.Add(cycleNumber, cycleMembers);
                        }
                    }
                }
            }
            visitedOneSearch.Pop();
        }
    }
}
