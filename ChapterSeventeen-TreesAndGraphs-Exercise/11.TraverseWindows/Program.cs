using System;
using System.IO;

namespace _11.TraverseWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            TraverseDir("C:\\Windows\\assembly");
        }

        static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            foreach (var file in dir.GetFiles("*.exe"))
            {
                Console.WriteLine(file.Name);
            }

            DirectoryInfo[] children = dir.GetDirectories();

            foreach (DirectoryInfo child in children)
            {
                TraverseDir(child, spaces + "  ");
            }
        }

        static void TraverseDir(string directoyPath) => TraverseDir(new DirectoryInfo(directoyPath), string.Empty);
    }
}
