using System;

namespace Seventh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length <= 20)
            {
                while (input.Length < 20)
                {
                    input += "*";
                }
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Long input!");
            }
        }
    }
}
