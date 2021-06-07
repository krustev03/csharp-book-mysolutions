using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _03.CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"text.txt");
            string[] files = File.ReadAllLines(path);

            var result = GetWordsOccurences(files[0]);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        static IDictionary<string, int> GetWordsOccurences(string text)
        {
            string[] tokens = text.Split(' ', '.', '?', '!', '-', ',');

            var words = new SortedDictionary<string, int>();

            foreach (var word in tokens)
            {
                if (!string.IsNullOrEmpty(word.Trim()))
                {
                    int count = 0;
                    words.TryGetValue(word.ToLower(), out count);
                    words[word.ToLower()] = count + 1;
                }
            }

            return words;
        }
    }
}
