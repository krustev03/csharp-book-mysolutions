using System;
using System.Text;

namespace Sixth
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder text = new StringBuilder();
            string check = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '<')
                {
                    
                    if (input.Substring(input.IndexOf('<', i), 8) == "<upcase>")
                    {
                        while (true)
                        {
                            i++;
                            if (input[i + 1] == '<')
                            {
                                if (input.Substring(input.IndexOf('<', i + 1), 9) == "<//upcase>")
                                {
                                    text.Append((char)(input[i] - 32));
                                    break;
                                }
                            }
                            text.Append((char)(input[i] - 32));
                            
                            
                        }
                    }
                }
            }
        }
    }
}
