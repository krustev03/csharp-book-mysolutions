using System;
using System.Collections.Generic;

namespace _11.BFSLabyrinth
{
    class Program
    {
        static int rows = 5;
        static int columns = 7;

        static int[,] m = new int[,]
        {
                { 'S', '.', '.', '#', '.', '.', '.' },
                { '.', '#', '.', '.', '.', '#', '.' },
                { '.', '#', '.', '.', '.', '.', '.' },
                { '.', '.', '#', '#', '.', '.', '.' },
                { '#', '.', '#', 'E', '.', '#', '.' }
        };

        static int startRow = 0;
        static int startColumn = 0;

        static Queue<int> rowQueue = new Queue<int>();
        static Queue<int> columnQueue = new Queue<int>();

        static int moveCount = 0;
        static int nodesLeftInLayer = 1;
        static int nodesInNextLayer = 0;

        static bool reachedEnd = false;

        static bool[,] visited = new bool[rows, columns];

        static int[] dr = new int[] { -1, 1, 0, 0 };
        static int[] dc = new int[] { 0, 0, 1, -1 };

        static void Main(string[] args)
        {
            Solve();
        }

        static void Solve()
        {
            rowQueue.Enqueue(startRow);
            columnQueue.Enqueue(startColumn);

            visited[startRow, startColumn] = true;

            while (rowQueue.Count > 0)
            {
                int row = rowQueue.Dequeue();
                int column = columnQueue.Dequeue();

                if (m[row, column] == 'E')
                {
                    reachedEnd = true;
                    break;
                }

                ExploreNeighbours(row, column);

                nodesLeftInLayer--;

                if (nodesLeftInLayer == 0)
                {
                    nodesLeftInLayer = nodesInNextLayer;
                    nodesInNextLayer = 0;
                    moveCount++;
                    Console.WriteLine($"({row}, {column})");
                }
            }

            if (reachedEnd)
            {
                return;
            }

            return;
        }

        static void ExploreNeighbours(int row, int column)
        {
            for (int i = 0; i < 4; i++)
            {
                int rr = row + dr[i];
                int cc = column + dc[i];

                if (rr < 0 || cc < 0) continue;

                if (rr >= rows || cc >= columns) continue;

                if (visited[rr, cc]) continue;

                if (m[rr, cc] == '#') continue;

                rowQueue.Enqueue(rr);
                columnQueue.Enqueue(cc);
                visited[rr, cc] = true;
                nodesInNextLayer++;
            }
        }
    }
}
