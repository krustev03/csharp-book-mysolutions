using System;

namespace Nineth
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cipher = Console.ReadLine();
            int k = 0;
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("\\u" + (input[i]^cipher[k]).ToString("x4"));
                k++;
                if (k == cipher.Length)
                {
                    k = 0;
                }
            }
        }
    }
}
