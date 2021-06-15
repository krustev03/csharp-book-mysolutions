using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CountSubtringsInFile
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //string[] words = File.ReadAllLines("words.txt");

            //int[] occurences = new int[words.Length];

            //using (StreamReader text = File.OpenText("text.txt"))
            //{
            //    string line;

            //    while ((line = text.ReadLine()) != null)
            //    {
            //        for (int i = 0; i < words.Length; i++)
            //        {
            //            string word = words[i];
            //            int wordOccurences = CountOccurencesIgnoreCase(word, line);
            //            occurences[i] += wordOccurences;
            //        }
            //    }
            //}

            //using (StreamWriter result = new StreamWriter("result.txt"))
            //{
            //    for (int i = 0; i < words.Length; i++)
            //    {
            //        result.WriteLine("{0} --> {1}", words[i], occurences[i]);
            //    }
            //}

            string[] wordsOriginal = File.ReadAllLines("words.txt");
            string[] wordsLowerCase = wordsOriginal.Select(w => w.ToLower()).ToArray();

            int[] occurences = new int[wordsLowerCase.Length];
            StringBuilder buffer = new StringBuilder();

            using (StreamReader text = File.OpenText("text.txt"))
            {
                int nextChar;
                while ((nextChar = text.Read()) != -1)
                {
                    char ch = (char)nextChar;

                    if (char.IsLetter(ch))
                    {

                        ch = char.ToLower(ch);
                        buffer.Append(ch);

                        for (int i = 0; i < wordsLowerCase.Length; i++)
                        {
                            string word = wordsLowerCase[i];

                            if (buffer.EndsWith(word))
                            {
                                occurences[i]++;
                            }
                        }
                    }

                    else
                    {
                        buffer.Clear();
                    }
                }
            }

            using (StreamWriter result = File.CreateText("result.txt"))
            {
                for (int i = 0; i < wordsOriginal.Length; i++)
                {
                    result.WriteLine("{0} --> {1}", wordsOriginal[i], occurences[i]);
                }
            }
        }

        static int CountOccurencesIgnoreCase(string substring, string text)
        {
            int count = 0;
            int index = -1;

            while (true)
            {
                index = text.IndexOf(substring, index + 1, StringComparison.OrdinalIgnoreCase);

                if (index == -1)
                {
                    break;
                }

                count++;
            }

            return count;
        }

        static bool EndsWith(this StringBuilder buffer, string str)
        {
            if (buffer.Length < str.Length)
            {
                return false;
            }

            for (int bufIndex = buffer.Length - str.Length, strIndex = 0; strIndex < str.Length; bufIndex++, strIndex++)
            {
                if (buffer[bufIndex] != str[strIndex])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
