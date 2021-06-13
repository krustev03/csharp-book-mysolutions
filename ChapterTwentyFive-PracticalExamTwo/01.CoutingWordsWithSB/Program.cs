using System;
using System.Text;

namespace _01.CoutingWordsWithSB
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ReadText();
            CountWords(text);
        }

        static string ReadText()
        {
            Console.WriteLine("Enter text:");
            return Console.ReadLine();
        }

        static void CountWords(string text)
        {
            StringBuilder sb = new StringBuilder();
            int allUpperCaseWordsCount = 0;
            int allLowerCaseWordsCount = 0;
            int allWordsCount = 0;

            foreach (var c in text)
            {
                if (Char.IsLetter(c))
                {
                    sb.Append(c);
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        allWordsCount++;

                        string word = sb.ToString();

                        if (IsUpperCase(word))
                        {
                            allUpperCaseWordsCount++;
                        }
                        else if (IsLowerCase(word))
                        {
                            allLowerCaseWordsCount++;
                        }

                        sb.Clear();
                    }
                }
            }

            if (sb.Length > 0)
            {
                allWordsCount++;

                string word = sb.ToString();

                if (IsUpperCase(word))
                {
                    allUpperCaseWordsCount++;
                }
                else if (IsLowerCase(word))
                {
                    allLowerCaseWordsCount++;
                }

                sb.Clear();
            }

            Console.WriteLine($"Total words count: {allWordsCount}");
            Console.WriteLine($"Upper case words count: {allUpperCaseWordsCount}");
            Console.WriteLine($"Lower case words count: {allLowerCaseWordsCount}");
        }

        static bool IsUpperCase(string word) => word.Equals(word.ToUpper());

        static bool IsLowerCase(string word) => word.Equals(word.ToLower());
    }
}
