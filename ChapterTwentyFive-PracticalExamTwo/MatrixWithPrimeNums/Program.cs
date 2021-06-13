using System;

namespace MatrixWithPrimeNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = ReadInput();
            PrintMatrixOfPrimes(n);
        }

        static int ReadInput()
        {
            Console.Write("N = ");
            string input = Console.ReadLine();
            int n = int.Parse(input);
            return n;
        }

        static bool IsPrime(int num)
        {
            if (num == 2)
            {
                return true;
            }

            if (num % 2 == 0)
            {
                return false;
            }

            int maxDivider = (int)Math.Sqrt(num);

            for (int i = 3; i <= maxDivider; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static int FindNextPrime(int startNumber)
        {
            int number = startNumber;

            while (!IsPrime(number))
            {
                number++;
            }

            return number;
        }

        static void PrintMatrixOfPrimes(int dimension)
        {
            int lastPrime = 1;

            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    int nextPrime = FindNextPrime(lastPrime + 1);
                    Console.Write("{0,4}", nextPrime);
                    lastPrime = nextPrime;
                }

                Console.WriteLine();
            }
        }
    }
}
