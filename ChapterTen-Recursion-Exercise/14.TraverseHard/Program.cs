using System;
using System.IO;

namespace _14.TraverseHard
{
    class Program
    {
        static void Main(string[] args)
        {
            TraverseDir("C:\\Windows\\assembly");
        }

        static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            Console.WriteLine(dir.Name);

            foreach (var file in dir.GetFiles())
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
