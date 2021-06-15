using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.FileSystem
{
    public class Directory
    {
        private string name;
        private DateTime creationDate;
        private List<Directory> directories;
        private List<File> files;
        private Directory parentDirectory;

        public Directory(string name, Directory parentDirectory)
        {
            this.name = name;
            this.creationDate = DateTime.Now;
            this.directories = new List<Directory>();
            this.files = new List<File>();
            this.parentDirectory = parentDirectory;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public DateTime CreationDate
        {
            get => this.creationDate;
        }

        public List<Directory> Directories
        {
            get => this.directories;
            set => this.directories = value;
        }

        public List<File> Files
        {
            get => this.files;
            set => this.files = value;
        }

        public Directory ParentDirectory
        {
            get => this.parentDirectory;
            set => this.parentDirectory = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Directory name: {this.name}");
            sb.AppendLine($"Creation date: {this.creationDate.ToString("MM / dd / yyyy H: mm")}");

            if (this.parentDirectory != null)
            {
                sb.AppendLine($"Parent directory: {this.parentDirectory.Name}");
            }
            else
            {
                sb.AppendLine($"Parent directory: none");
            }

            if (!this.directories.Any())
            {
                sb.AppendLine("Directories: none\n");
            }
            else
            {
                sb.AppendLine("Directories:\n");

                foreach (var directory in this.directories)
                {
                    sb.AppendLine($"{String.Join(Environment.NewLine, directory.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(line => " " + line))}\n");
                }
            }

            sb.AppendLine("Files:\n");

            foreach (var file in this.files)
            {
                sb.AppendLine($"{file}\n");
            }

            return sb.ToString();
        }
    }
}
