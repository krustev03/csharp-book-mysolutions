using System;

namespace Fifth
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string keyword = Console.ReadLine();
            int index = 0;
            int count = 0;

            while (index != -1)
            {
                count++;
                index = input.IndexOf(keyword, index + keyword.Length);
                
            }
            Console.WriteLine(count);
        }
    }
}
