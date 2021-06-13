using System;

namespace _02.SieveOfEratosthenes
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

        static void PrintMatrixOfPrimes(int dimension)
        {
            long sieveSize = (long)Math.Truncate(2.4 * dimension * dimension * Math.Log(dimension, Math.E)) + 2;
            int count = 0;
            int counter = 0;

            for (int i = 2; i <= sieveSize; i++)
            {
                if (count == dimension * dimension)
                {
                    break;
                }

                if (IsPrime(i))
                {
                    Console.Write("{0,4}", i);
                    counter++;
                    count++;
                }
                if (counter == dimension)
                {
                    Console.WriteLine();
                    counter = 0;
                }
            }
        }
    }
}
