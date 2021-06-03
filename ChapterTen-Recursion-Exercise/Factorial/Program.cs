using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Factorial(3);
            Console.WriteLine(result);
        }

        static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
