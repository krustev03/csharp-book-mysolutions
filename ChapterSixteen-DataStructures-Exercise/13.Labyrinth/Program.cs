using System;
using System.Collections.Generic;

namespace _13.Labyrinth
{
    class Program
    {
        static int n = 6;

        static string[,] m = new string[,]
        {
                { "0", "0", "0", "X", "0", "X"},
                { "0", "X", "0", "X", "0", "X"},
                { "0", "*", "X", "0", "X", "0"},
                { "0", "X", "0", "0", "0", "0"},
                { "0", "0", "0", "X", "X", "0"},
                { "0", "0", "0", "X", "0", "X"}
        };

        static int startRow = 2;
        static int startColumn = 1;

        static Queue<int> rowQueue = new Queue<int>();
        static Queue<int> columnQueue = new Queue<int>();

        static int moveCount = 0;
        static int nodesLeftInLayer = 1;
        static int nodesInNextLayer = 0;

        static bool[,] visited = new bool[n, n];

        static int[] dr = new int[] { -1, 1, 0, 0 };
        static int[] dc = new int[] { 0, 0, 1, -1 };

        static void Main(string[] args)
        {
            int result = Solve();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] == "0")
                    {
                        m[i, j] = "u";
                    }

                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int Solve()
        {
            rowQueue.Enqueue(startRow);
            columnQueue.Enqueue(startColumn);

            visited[startRow, startColumn] = true;
            int counter = 1;

            while (rowQueue.Count > 0)
            {
                int row = rowQueue.Dequeue();
                int column = columnQueue.Dequeue();

                ExploreNeighbours(row, column, counter);

                nodesLeftInLayer--;

                if (nodesLeftInLayer == 0)
                {
                    nodesLeftInLayer = nodesInNextLayer;
                    nodesInNextLayer = 0;
                    moveCount++;
                    counter++;
                }
            }

            return -1;
        }

        static void ExploreNeighbours(int row, int column, int counter)
        {
            for (int i = 0; i < 4; i++)
            {
                int rr = row + dr[i];
                int cc = column + dc[i];

                if (rr < 0 || cc < 0) continue;

                if (rr >= n || cc >= n) continue;

                if (visited[rr, cc]) continue;

                if (m[rr, cc] == "X") continue;

                rowQueue.Enqueue(rr);
                columnQueue.Enqueue(cc);
                if (visited[rr, cc] == false && m[rr, cc] != "*")
                {
                    m[rr, cc] = counter.ToString();
                }
                visited[rr, cc] = true;
                
                nodesInNextLayer++;
            }
        }
    }
}
