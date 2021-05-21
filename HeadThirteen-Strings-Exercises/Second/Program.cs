using System;
using System.Text;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(DateTime.Now);
            // First variant:
            //char[] chars = str.ToCharArray();
            //Array.Reverse(chars);
            //string newMsg = string.Empty;
            //foreach (var letter in chars)
            //{
            //    newMsg += letter;
            //}
            //Console.WriteLine(newMsg);
            // Second variant:
            StringBuilder reversed = new StringBuilder();
            reversed.Append(str);
            Reverse(reversed);
            Console.WriteLine(reversed);
            Console.WriteLine(DateTime.Now);
        }
        public static void Reverse(StringBuilder sb)
        {
            char t;
            int end = sb.Length - 1;
            int start = 0;

            while (end - start > 0)
            {
                t = sb[end];
                sb[end] = sb[start];
                sb[start] = t;
                start++;
                end--;
            }
        }
    }
}
