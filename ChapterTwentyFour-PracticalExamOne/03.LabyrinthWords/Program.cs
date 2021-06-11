using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _03.LabyrinthWords
{
    class Program
    {
        const string InputFileName = "Problem.in";
        const string OutputFileName = "Problem.out";
        static List<string> words = new List<string>();

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
            private char[] path;
            static int position = 0;

            public void ReadFromFile(string fileName)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    this.size = int.Parse(reader.ReadLine());
                    this.path = new char[this.size * this.size];
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

            public void GetAllWords()
            {
                if (this.startCell == null)
                {
                    return;
                }

                FindExitWords(this.startCell.Row, this.startCell.Column, '*');
            }

            public void FindExitWords(int row, int column, char letter)
            {
                path[position] = letter;
                position++;

                this.maze[row, column] = '#';

                if ((row == 0) || (row == size - 1) ||
                    (column == 0) || (column == size - 1))
                {
                    SaveWord(path, 1, position - 1);
                }

                if (row + 1 < size && this.maze[row + 1, column] != '#')
                {
                    FindExitWords(row + 1, column, this.maze[row + 1, column]);
                }

                if (row - 1 >= 0 && this.maze[row - 1, column] != '#')
                {
                    FindExitWords(row - 1, column, this.maze[row - 1, column]);
                }

                if (column + 1 < size && this.maze[row, column + 1] != '#')
                {
                    FindExitWords(row, column + 1, this.maze[row, column + 1]);
                }

                if (column - 1 >= 0 && this.maze[row, column - 1] != '#')
                {
                    FindExitWords(row, column - 1, this.maze[row, column - 1]);
                }

                this.maze[row, column] = letter;

                position--;
            }

            public void SaveWord(char[] path, int start, int end)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = start; i <= end; i++)
                {
                    sb.Append(path[i]);
                }

                words.Add(sb.ToString());
            }
        }

        static void Main(string[] args)
        {
            Maze maze = new Maze();
            maze.ReadFromFile(InputFileName);
            maze.GetAllWords();
            WriteWordsInFile();
        }

        static void WriteWordsInFile()
        {
            using (StreamWriter writer = new StreamWriter(OutputFileName))
            {
                foreach (var word in words)
                {
                    writer.WriteLine(word);
                }
            }
        }
    }
}
