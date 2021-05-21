using System;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    count++;
                }
                else if (input[i] == ')')
                {
                    count--;
                }
                if (count == -1)
                {
                    Console.WriteLine("Wrong algorithm!");
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Right algorithm!");
            }
        }
    }
}
