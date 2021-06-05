using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.LongestSequenceInLabyrinth
{
    class Program
    {
        static int rows = 5;
        static int columns = 7;

        static int[,] m = new int[,]
        {
                { '.', '.', '.', '#', '.', '.', '.' },
                { '.', '#', '.', '.', '.', '#', '.' },
                { '.', '#', '.', '.', '.', '.', '.' },
                { '.', '.', '#', '#', '.', '.', '.' },
                { '#', '.', '#', '.', '.', '#', '.' }
        };

        static bool[,] visited = new bool[rows, columns];

        static Dictionary<int, List<string>> paths = new Dictionary<int, List<string>>();
        static List<string> currPath = new List<string>();
        static int pathCounter = 1;

        static int[] dr = new int[] { -1, 1, 0, 0 };
        static int[] dc = new int[] { 0, 0, 1, -1 };

        static void Main(string[] args)
        {
            paths.Add(pathCounter, new List<string>());

            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns; k++)
                {
                    if (m[i, k] == '.')
                    {
                        Solve(i, k);
                        break;
                    }
                }
            }

            var longestPath = paths.OrderByDescending(x => x.Value.Count).FirstOrDefault();

            foreach (var cell in longestPath.Value)
            {
                Console.WriteLine(cell);
            }
        }

        static void Solve(int row, int column)
        {
            visited[row, column] = true;
            currPath.Add($"({row}, {column})");

            var neighbours = ExploreNeighbours(row, column);

            foreach (var neighbour in neighbours)
            {
                var coordinates = neighbour.Value;
                if (!visited[coordinates[0], coordinates[1]])
                {
                    Solve(coordinates[0], coordinates[1]);
                }
            }

            if (!neighbours.Any())
            {
                var copyOfCurrPath = new List<string>();

                foreach (var item in currPath)
                {
                    copyOfCurrPath.Add(item);
                }

                paths[pathCounter] = copyOfCurrPath;
                pathCounter++;
                paths.Add(pathCounter, new List<string>());
            }

            currPath.RemoveAt(currPath.Count - 1);
        }

        static Dictionary<int , List<int>> ExploreNeighbours(int row, int column)
        {
            Dictionary<int, List<int>> listOfNeighbours = new Dictionary<int, List<int>>();
            int counter = 1;

            for (int i = 0; i < 4; i++)
            {
                int rr = row + dr[i];
                int cc = column + dc[i];

                if (rr < 0 || cc < 0) continue;

                if (rr >= rows || cc >= columns) continue;

                if (visited[rr, cc]) continue;

                if (m[rr, cc] == '#') continue;

                listOfNeighbours.Add(counter, new List<int>());
                listOfNeighbours[counter].Add(rr);
                listOfNeighbours[counter].Add(cc);
                counter++;
            }

            return listOfNeighbours;
        }
    }
}
