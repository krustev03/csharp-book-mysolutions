using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _02.CountWords
{
    public static class Program
    {
        static void Main(string[] args)
        {
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
            }

            using (StreamWriter result = File.CreateText("result.txt"))
            {
                for (int i = 0; i < wordsOriginal.Length; i++)
                {
                    result.WriteLine("{0} --> {1}", wordsOriginal[i], occurences[i]);
                }
            }
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
