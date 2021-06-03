using System;

namespace NLoopsKNums
{
    class Program
    {
        static void Main(string[] args)
        {
            IterativeLoops();
        }

        static int n = 3;
        static int k = 3;
        static int[] loops = new int[n];

        static void RecursiveLoops(int currentLoop)
        {
            if (currentLoop == n)
            {
                PrintLoops();
                return;
            }

            for (int i = 1; i <= k; i++)
            {
                loops[currentLoop] = i;
                RecursiveLoops(currentLoop + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(loops[i] + " ");
            }
            Console.WriteLine();
        }

        static void IterativeLoops()
        {
            InitLoops();

            int currentPosition;

            while (true)
            {
                PrintLoops();

                currentPosition = n - 1;
                loops[currentPosition] = loops[currentPosition] + 1;

                while (loops[currentPosition] > k)
                {
                    loops[currentPosition] = 1;
                    currentPosition--;

                    if (currentPosition < 0)
                    {
                        return;
                    }
                    loops[currentPosition] = loops[currentPosition] + 1;
                }
            }
        }

        static void InitLoops()
        {
            for (int i = 0; i < n; i++)
            {
                loops[i] = 1;
            }
        }
    }
}
