using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.GraphShortestW
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
            FindShortestWay(1, 3);
        }

        static void FindShortestWay(int s, int e)
        {
            var prev = BFS(s);

            var result = ReconstructPath(s, e, prev);

            foreach (var item in result)
            {
                Console.Write(item + "-");
            }
            Console.Write(e);
        }

        static int?[] BFS(int s)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);

            bool[] visited = new bool[graph.Size];
            visited[s] = true;

            int?[] prev = new int?[graph.Size];

            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = null;
            }

            while (queue.Any())
            {
                int node = queue.Dequeue();

                var neighbours = graph.GetSuccessors(node);

                foreach (var neighbour in neighbours)
                {
                    if (!visited[neighbour])
                    {
                        queue.Enqueue(neighbour);
                        visited[neighbour] = true;
                        prev[neighbour] = node;
                    }
                }
            }

            return prev;
        }

        static List<int?> ReconstructPath(int s, int e, int?[] prev)
        {
            var path = new List<int?>();

            for (int? i = e; i != null;)
            {
                int j = (int)i;
                if (prev[j] != null)
                {
                    path.Add(prev[j]);
                    i = prev[j];
                }
                if (prev[j] == null)
                {
                    break;
                }
            }

            path.Reverse();

            if (path[0] == s)
            {
                return path;
            }

            return new List<int?>();
        }
    }
}
