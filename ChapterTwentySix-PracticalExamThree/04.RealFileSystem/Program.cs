using System;
using System.IO;
using System.Text;

namespace _04.RealFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerStorage storage = new ComputerStorage("My Computer Storage");
            string[] drives = Environment.GetLogicalDrives();

            foreach (string dr in drives)
            {
                DriveInfo di = new DriveInfo(dr);

                if (!di.IsReady)
                {
                    Console.WriteLine($"The drive {di.Name} could not be read");
                    continue;
                }
                
                DirectoryInfo rootDir = di.RootDirectory;
                Directory directoryTree = new Directory(rootDir.FullName, rootDir.CreationTime, null);
                Device device = new Device(di.Name, directoryTree);
                storage.Devices.Add(device);
                WalkDirectoryTree(rootDir, directoryTree);
            }
        }

        static void WalkDirectoryTree(DirectoryInfo root, Directory directory)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    try
                    {
                        FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                        byte[] fileBytes = new byte[128];

                        fs.Read(fileBytes, 0, 128);
                        fs.Close();

                        File file;

                        if (fi.Extension == ".txt")
                        {
                            string filestring = Encoding.UTF8.GetString(fileBytes);

                            file = new TextFile(fi.Name, fi.CreationTime, fi.LastWriteTime, directory, filestring);
                        }
                        else
                        {
                            file = new BinaryFile(fi.Name, fi.CreationTime, fi.LastWriteTime, directory, fileBytes);
                        }

                        directory.Files.Add(file);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    Directory newDir = new Directory(dirInfo.FullName, dirInfo.CreationTime, directory);
                    directory.Directories.Add(newDir);
                    WalkDirectoryTree(dirInfo, newDir);
                }
            }
        }
    }
}
