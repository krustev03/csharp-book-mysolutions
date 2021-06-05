using System;

namespace _10.FindPathsBetweenTwoCells
{
    class Program
    {
        static char[,] lab =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;

        static void Main(string[] args)
        {
            FindPath(0, 0, 'S');
        }

        static void FindPath(int row, int col, char direction)
        {
            if ((col < 0) || (col >= lab.GetLength(1)) ||
                (row < 0) || (row >= lab.GetLength(0)))
            {
                return;
            }

            path[position] = direction;
            position++;

            if (lab[row, col] == 'e')
            {
                PrintPath(path, 1, position - 1);
            }

            if (lab[row, col] == ' ')
            {
                lab[row, col] = 's';

                FindPath(row, col - 1, 'L');
                FindPath(row - 1, col, 'U');
                FindPath(row, col + 1, 'R');
                FindPath(row + 1, col, 'D');

                lab[row, col] = ' ';
            }

            position--;
        }

        static void PrintPath(char[] path, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(path[i]);
            }
            Console.WriteLine();
        }
    }
}
