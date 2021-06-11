using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HTMLScraper
{
    class Program
    {
        const string InputFileName = "Problem1.html";
        const string OutputFileName = "Problem1.txt";
        static readonly Regex regexWhitespace = new Regex("\n\\s+");

        static void Main(string[] args)
        {
            if (!File.Exists(InputFileName))
            {
                Console.WriteLine($"File {InputFileName} was not found.");
                return;
            }

            using (var reader = new StreamReader(InputFileName))
            {
                using (var writer = new StreamWriter(OutputFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        RemoveHtmlTags(reader, writer);
                    }
                }
            }
        }

        static void RemoveHtmlTags(StreamReader reader, StreamWriter writer)
        {
            StringBuilder buffer = new StringBuilder();
            int openedTags = 0;

            while (true) 
            {
                int nextChar = reader.Read();

                if (nextChar == -1)
                {
                    PrintBuffer(writer, buffer);
                    break;
                }

                char ch = (char)nextChar;

                if (ch == '<')
                {
                    if (openedTags == 0)
                    {
                        PrintBuffer(writer, buffer);
                    }
                    buffer.Clear();
                    openedTags++;
                }

                else if (ch == '>')
                {
                    openedTags--;
                }

                else
                {
                    if (openedTags == 0)
                    {
                        buffer.Append(ch);
                    }
                }
            }
        }

        static void PrintBuffer(StreamWriter output, StringBuilder buffer)
        {
            string str = buffer.ToString();
            string trimmed = str.Trim();
            string textOnly = regexWhitespace.Replace(trimmed, "\n");

            if (!string.IsNullOrEmpty(textOnly))
            {
                output.WriteLine(textOnly);
            }
        }

        static string RemoveAllTags(string str) => Regex.Replace(str, "<[^>]*>", "\n");

        static string TrimNewLines(string str) 
        {
            int start = 0;

            while (start < str.Length && str[start] == '\n')
            {
                start++;
            }

            int end = str.Length - 1;

            while (end >= 0 && str[end] == '\n')
            {
                end--;
            }

            if (start > end)
            {
                return string.Empty;
            }

            string trimmed = str.Substring(start, end - start + 1);
            return trimmed;
        }

        static string RemoveNewLinesWithWhiteSpace(string str)
        {
            string pattern = "\n\\s+";
            return Regex.Replace(str, pattern, "\n");
        }
    }
}
