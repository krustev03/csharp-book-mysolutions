using System;
using System.Collections.Generic;
using System.IO;

namespace _12.DirTraverseDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            TraverseDir("C:\\Windows\\assembly");
        }

        public static void TraverseDir(string directoryPath)
        {
            Stack<DirectoryInfo> visitedDirs = new Stack<DirectoryInfo>();
            visitedDirs.Push(new DirectoryInfo(directoryPath));

            while (visitedDirs.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirs.Pop();
                Console.WriteLine(currentDir.FullName);

                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    visitedDirs.Push(child);
                }
            }
        }
    }
}
