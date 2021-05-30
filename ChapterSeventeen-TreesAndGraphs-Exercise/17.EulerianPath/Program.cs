using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.EulerianPath
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

        static Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

        static LinkedList<int> path = new LinkedList<int>();

        static int n = 5;

        static void Main(string[] args)
        {
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            // If you use this graph, set n = 7
            //graph[0].Add(new Edge(0, 1, 3));
            //graph[0].Add(new Edge(0, 2, 2));
            //graph[0].Add(new Edge(0, 5, 3));
            //graph[1].Add(new Edge(1, 3, 1));
            //graph[1].Add(new Edge(1, 2, 6));
            //graph[2].Add(new Edge(2, 3, 1));
            //graph[2].Add(new Edge(2, 4, 10));
            //graph[3].Add(new Edge(3, 4, 5));
            //graph[5].Add(new Edge(5, 4, 7));

            graph[0].Add(new Edge(0, 2, 3));
            graph[1].Add(new Edge(1, 0, 2));
            graph[1].Add(new Edge(1, 2, 3));
            graph[1].Add(new Edge(1, 3, 1));
            graph[2].Add(new Edge(2, 1, 6));
            graph[2].Add(new Edge(2, 3, 1));
            graph[3].Add(new Edge(3, 1, 10));
            graph[3].Add(new Edge(3, 4, 5));
            graph[4].Add(new Edge(4, 1, 7));

            var result = FindEulerianPath();

            if (result != null)
            {
                Console.WriteLine("The Eulerian Path is: ");
                foreach (var item in result)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.WriteLine("No Eulerian Path");
            }
        }

        static int[] inDegrees = new int[n];
        static int[] outDegrees = new int[n];

        static LinkedList<int> FindEulerianPath()
        {
            CountInOutDegrees();
            if (!GraphHasEulerianPath())
            {
                return null;
            }

            DFS(FindStartNode());

            var edgesCount = 0;

            foreach (var item in graph)
            {
                foreach (var edge in graph[item.Key])
                {
                    edgesCount++;
                }
            }

            if (path.Count == edgesCount + 1)
            {
                return path;
            }

            return null;
        }

        static void CountInOutDegrees()
        {
            foreach (var node in graph)
            {
                foreach (var edge in graph[node.Key])
                {
                    // Fix here
                    outDegrees[edge.From]++;
                    inDegrees[edge.To]++;
                }
            }
        }

        static bool GraphHasEulerianPath()
        {
            var startNodes = 0;
            var endNodes = 0;

            for (int i = 0; i < graph.Count; i++)
            {
                if ((outDegrees[i] - inDegrees[i]) > 1 || (inDegrees[i] - outDegrees[i]) > 1)
                {
                    return false;
                }

                else if (outDegrees[i] - inDegrees[i] == 1)
                {
                    startNodes++;
                }

                else if (inDegrees[i] - outDegrees[i] == 1)
                {
                    endNodes++;
                }
            }

            return (endNodes == 0 && startNodes == 0) || (endNodes == 1 && startNodes == 1);
        }

        static int FindStartNode()
        {
            int start = 0;

            for (int i = 0; i < graph.Count; i++)
            {
                if (outDegrees[i] - inDegrees[i] == 1)
                {
                    return i;
                }
                if (outDegrees[i] > 0)
                {
                    start = i;
                }
            }

            return start;
        }

        static void DFS(int v)
        {
            while (outDegrees[v] != 0)
            {
                var nextEdge = graph[v].ElementAt(--outDegrees[v]);
                DFS(nextEdge.To);
            }

            path.AddFirst(v);
        }
    }
}
