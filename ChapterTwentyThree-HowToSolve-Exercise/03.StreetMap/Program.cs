using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace _03.StreetMap
{
    class Program
    {
        public class CrossRoad
        {
            private string name;
            private int index;
            private Dictionary<CrossRoad, int> streets;

            public CrossRoad(string name, int index)
            {
                this.name = name;
                this.index = index;
                this.streets = new Dictionary<CrossRoad, int>();
            }

            public string Name
            {
                get => this.name;
                set => this.name = value;
            }

            public int Index
            {
                get => this.index;
                set => this.index = value;
            }

            public Dictionary<CrossRoad, int> Streets
            {
                get => this.streets;
                set => this.streets = value;
            }
        }

        static List<CrossRoad> map = new List<CrossRoad>();
        static List<string[]> pathsToFind = new List<string[]>();

        static void Main(string[] args)
        {
            ProceedInput();

            foreach (var path in pathsToFind)
            {
                var startIndex = map.Where(cr => cr.Name == path[0]).FirstOrDefault().Index;
                var endIndex = map.Where(cr => cr.Name == path[1]).FirstOrDefault().Index;

                var result = Djikstra(startIndex);

                if (result[endIndex] == int.MaxValue)
                {
                    Console.WriteLine("No path!");
                    continue;
                }
                Console.WriteLine(result[endIndex]);
            }
        }

        static int[] Djikstra(int s)
        {
            int[] dist = new int[map.Count];
            bool[] visited = new bool[map.Count];

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
                var minValue = element.Value;

                visited[index] = true;

                if (dist[index] < minValue)
                {
                    continue;
                }

                foreach (var edge in map.Where(cr => cr.Index == index).FirstOrDefault().Streets)
                {
                    if (visited[edge.Key.Index])
                    {
                        continue;
                    }

                    var newDist = dist[index] + edge.Value;

                    if (newDist < dist[edge.Key.Index])
                    {
                        dist[edge.Key.Index] = newDist;

                        if (!distDic.ContainsKey(edge.Key.Index))
                        {
                            distDic.Add(edge.Key.Index, newDist);
                        }
                        else
                        {
                            distDic[edge.Key.Index] = newDist;
                        }
                    }
                }
            }

            return dist;
        }

        static void ProceedInput()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"map.txt");
            string[] files = File.ReadAllLines(path);

            int counter = 0;
            int index = 0;
            bool proceededStreets = false;

            foreach (var line in files)
            {
                if (line == "")
                {
                    if (proceededStreets)
                    {
                        break;
                    }

                    proceededStreets = true;
                    continue;
                }

                string[] tokens = line.Split(' ');

                if (!proceededStreets)
                {
                    var firstCr = map.Where(cr => cr.Name == tokens[0]).FirstOrDefault();

                    if (firstCr == null)
                    {
                        firstCr = new CrossRoad(tokens[0], index);
                        index++;
                        map.Add(firstCr);
                    }

                    var secondCr = map.Where(cr => cr.Name == tokens[1]).FirstOrDefault();

                    if (secondCr == null)
                    {
                        secondCr = new CrossRoad(tokens[1], index);
                        index++;
                        map.Add(secondCr);
                    }

                    firstCr.Streets.Add(secondCr, int.Parse(tokens[2]));
                    secondCr.Streets.Add(firstCr, int.Parse(tokens[2]));
                    counter++;
                }
                else
                {
                    pathsToFind.Add(new string[2] { tokens[0], tokens[1] });
                }
            }
        }
    }
}
