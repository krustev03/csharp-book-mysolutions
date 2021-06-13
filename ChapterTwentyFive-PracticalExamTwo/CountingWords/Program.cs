using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ReadText();
            string[] words = ExtractWords(text);
            CountWords(words);
        }

        static string ReadText()
        {
            Console.WriteLine("Enter text:");
            return Console.ReadLine();
        }

        static void CountWords(string[] words)
        {
            int allUpperCaseWordsCount = 0;
            int allLowerCaseWordsCount = 0;

            foreach (var word in words)
            {
                if (IsUpperCase(word))
                {
                    allUpperCaseWordsCount++;
                }
                else if (IsLowerCase(word))
                {
                    allLowerCaseWordsCount++;
                }
            }

            Console.WriteLine($"Total words count: {words.Length}");
            Console.WriteLine($"Upper case words count: {allUpperCaseWordsCount}");
            Console.WriteLine($"Lower case words count: {allLowerCaseWordsCount}");
        }

        static string[] ExtractWords(string text)
        {
            char[] separators = ExtractSeparators(text);

            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        static char[] ExtractSeparators(string text)
        {
            HashSet<char> separators = new HashSet<char>();

            foreach (var character in text)
            {
                if (!Char.IsLetter(character))
                {
                    separators.Add(character);
                }
            }

            return separators.ToArray();
        }

        static bool IsUpperCase(string word) => word.Equals(word.ToUpper());

        static bool IsLowerCase(string word) => word.Equals(word.ToLower());
    }
}
