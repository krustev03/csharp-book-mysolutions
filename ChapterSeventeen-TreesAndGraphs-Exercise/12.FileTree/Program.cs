using System;
using System.Collections.Generic;
using System.IO;

namespace _12.FileTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Folder treeFolder = CreateTree("C:\\Windows\\assembly", "assembly");
            var result = FindSum(treeFolder);
            Console.WriteLine(result + " bytes");
        }

        static void CreateTree(DirectoryInfo dir, Folder folder)
        {
            if (dir.GetFiles().Length > 0) 
            {
                var currDirFiles = dir.GetFiles();
                var files = new File[currDirFiles.Length];

                for (int i = 0; i < currDirFiles.Length; i++)
                {
                    files[i] = new File();
                    files[i].Name = currDirFiles[i].Name;
                    files[i].Size = currDirFiles[i].Length;
                }

                folder.Files = files;
            }
            else
            {
                folder.Files = null;
            }


            if (dir.GetDirectories().Length != 0)
            {
                var currDirFolders = dir.GetDirectories();
                var folders = new Folder[currDirFolders.Length];
                folder.ChildFolders = new Folder[currDirFolders.Length];

                for (int i = 0; i < currDirFolders.Length; i++)
                {
                    folders[i] = new Folder();
                    folders[i].Name = currDirFolders[i].Name;
                    CreateTree(currDirFolders[i], folders[i]);
                    folder.ChildFolders[i] = folders[i];
                }
            }
            else
            {
                folder.ChildFolders = null;
            }
        }

        static Folder CreateTree(string directoyPath, string folderName) 
        {
            var treeFolder = new Folder(folderName);
            CreateTree(new DirectoryInfo(directoyPath), treeFolder);
            return treeFolder;
        }

        public static long FindSum(Folder folder)
        {
            Queue<Folder> visitedFolders = new Queue<Folder>();
            visitedFolders.Enqueue(folder);
            long sum = 0;

            while (visitedFolders.Count > 0)
            {
                Folder currentFolder = visitedFolders.Dequeue();
                
                if (currentFolder.Files != null)
                {
                    foreach (var file in currentFolder.Files)
                    {
                        sum += file.Size;
                    }
                }

                if (currentFolder.ChildFolders != null)
                {
                    Folder[] children = currentFolder.ChildFolders;
                    foreach (Folder child in children)
                    {
                        visitedFolders.Enqueue(child);
                    }
                }
            }

            return sum;
        }
    }
}
