using System;
using System.Collections.Generic;
using System.IO;

namespace _11.DirTraverseBFS
{
    class Program
    {
        static void Main(string[] args)
        {
            TraverseDir("C:\\Windows\\assembly");
        }

        public static void TraverseDir(string directoryPath)
        {
            Queue<DirectoryInfo> visitedDirs = new Queue<DirectoryInfo>();
            visitedDirs.Enqueue(new DirectoryInfo(directoryPath));

            while (visitedDirs.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirs.Dequeue();
                Console.WriteLine(currentDir.FullName);

                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    visitedDirs.Enqueue(child);
                }
            }
        }
    }
}
