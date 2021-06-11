using System;
using System.Collections.Generic;
using System.IO;

namespace LabyrinthBFS
{
    class Program
    {
        const string InputFileName = "Problem2.in";
        const string OutputFileName = "Problem2.out";

        public class Cell
        {
            public Cell(int row, int column, int distance)
            {
                this.Row = row;
                this.Column = column;
                this.Distance = distance;
            }

            public int Row { get; set; }

            public int Column { get; set; }

            public int Distance { get; set; }
        }

        public class Maze
        {
            private char[,] maze;
            private int size;
            private Cell startCell = null;

            public void ReadFromFile(string fileName)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    this.size = int.Parse(reader.ReadLine());
                    this.maze = new char[this.size, this.size];

                    for (int row = 0; row < this.size; row++)
                    {
                        string line = reader.ReadLine();

                        for (int col = 0; col < this.size; col++)
                        {
                            this.maze[row, col] = line[col];

                            if (line[col] == '*')
                            {
                                this.startCell = new Cell(row, col, 0);
                            }
                        }
                    }
                }
            }

            public int FindShortestPath()
            {
                if (this.startCell == null)
                {
                    return -1;
                }

                Queue<Cell> visitedCells = new Queue<Cell>();
                VisitCell(visitedCells, this.startCell.Row, this.startCell.Column, 0);

                while (visitedCells.Count > 0)
                {
                    Cell currentCell = visitedCells.Dequeue();
                    int row = currentCell.Row;
                    int column = currentCell.Column;
                    int distance = currentCell.Distance;

                    if ((row == 0) || (row == size - 1) ||
                        (column == 0) || (column == size - 1))
                    {
                        return distance + 1;
                    }

                    VisitCell(visitedCells, row + 1, column, distance + 1);
                    VisitCell(visitedCells, row - 1, column, distance + 1);
                    VisitCell(visitedCells, row, column + 1, distance + 1);
                    VisitCell(visitedCells, row, column - 1, distance + 1);
                }

                return -1;
            }

            void VisitCell(Queue<Cell> visitedCells, int row, int column, int distance)
            {
                if (this.maze[row, column] != 'x')
                {
                    maze[row, column] = 'x';
                    Cell cell = new Cell(row, column, distance);
                    visitedCells.Enqueue(cell);
                }
            }

            public void SaveResult(string fileName, int result)
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"The shortest path is: {result}");
                }
            }
        }

        static void Main(string[] args)
        {
            Maze maze = new Maze();
            maze.ReadFromFile(InputFileName);
            int result = maze.FindShortestPath();
            maze.SaveResult(OutputFileName, result);
        }
    }
}
