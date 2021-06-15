using System;

namespace _03.FileSystem
{
    class ComputerStorageTest
    {
        static void Main(string[] args)
        {
            ComputerStorage storage = new ComputerStorage("My Storage");

            Device hardDisk = new Device("Hard Disk", null);
            Device cdRom = new Device("CD-ROM", null);

            Directory mainDir = new Directory("Main Directory", null);
            Directory secondDir = new Directory("Second Directory", mainDir);
            Directory thirdDir = new Directory("Third Directory", mainDir);
            Directory fourthDir = new Directory("Fourth Directory", secondDir);
            secondDir.Directories.Add(fourthDir);
            mainDir.Directories.Add(secondDir);
            mainDir.Directories.Add(thirdDir);

            File mainFile = new TextFile("Main File", mainDir, "mainnn");
            File mainFileTwo = new BinaryFile("Main File Two", mainDir, new byte[] { 1, 0, 1, 1, 0});
            File secondFile = new TextFile("Second File", secondDir, "secondddd");
            File thirdFile = new TextFile("Third File", thirdDir, "thirddd");
            File fourthFile = new TextFile("Fourth file", fourthDir, "fourrrrrr");

            mainDir.Files.Add(mainFile);
            mainDir.Files.Add(mainFileTwo);
            secondDir.Files.Add(secondFile);
            thirdDir.Files.Add(thirdFile);
            fourthDir.Files.Add(fourthFile);

            cdRom.DirectoryTree = mainDir;
            hardDisk.DirectoryTree = mainDir;

            storage.Devices.Add(cdRom);
            storage.Devices.Add(hardDisk);

            Console.WriteLine(storage);
        }
    }
}
