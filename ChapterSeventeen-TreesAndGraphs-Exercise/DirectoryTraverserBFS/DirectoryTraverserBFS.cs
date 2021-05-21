using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryTraverserBFS
{
    /// <summary> Sample class, which traverses recursively given directory, based on the Breadth-First Search (BFS) algorithm </summary>
    class DirectoryTraverserBFS
    {
        static void Main(string[] args)
        {
            TraverseDir("C:\\Windows\\assembly");
        }

        /// <summary> Traverses and prints given directory using BFS </summary>
        /// <param name="directoryPath">the path to the directory which should be traversed </param>
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
