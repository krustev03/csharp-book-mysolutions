using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.MinPaths
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

        static void Main(string[] args)
        {
            int n = 7;
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            graph[0].Add(new Edge(0, 1, 3));
            graph[0].Add(new Edge(0, 2, 2));
            graph[0].Add(new Edge(0, 5, 3));
            graph[1].Add(new Edge(1, 3, 1));
            graph[1].Add(new Edge(1, 2, 6));
            graph[2].Add(new Edge(2, 3, 1));
            graph[2].Add(new Edge(2, 4, 10));
            graph[3].Add(new Edge(3, 4, 5));
            graph[5].Add(new Edge(5, 4, 7));

            var result = Djikstra(0);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == int.MaxValue)
                {
                    Console.WriteLine(i + "-no path");
                }
                else
                {
                    Console.WriteLine(i + "-" + result[i]);
                }
            }
        }

        static int[] Djikstra(int s)
        {
            int[] dist = new int[graph.Count];
            bool[] visited = new bool[graph.Count];

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = int.MaxValue;
            }

            dist[s] = 0;

            var distDic = new SortedDictionary<int, int>();

            distDic.Add(s, 0);

            while (distDic.Any())
            {
                var element = distDic.ElementAt(0);
                distDic.Remove(element.Key);

                var index = element.Key;

                visited[index] = true;

                foreach (var edge in graph[index])
                {
                    if (visited[edge.To])
                    {
                        continue;
                    }

                    var newDist = dist[index] + edge.Weight;

                    if (newDist < dist[edge.To])
                    {
                        dist[edge.To] = newDist;

                        if (!distDic.ContainsKey(edge.To))
                        {
                            distDic.Add(edge.To, newDist);
                        }
                        else
                        {
                            distDic[edge.To] = newDist;
                        }
                    }
                }
            }

            return dist;
        }
    }
}
