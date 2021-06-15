using System;
using System.Text;

namespace _03.FileSystem
{
    abstract public class File
    {
        private string name;
        private DateTime creationDate;
        private DateTime lastUpdateDate;
        private Directory directory;

        public File(string name, Directory directory)
        {
            this.name = name;
            this.creationDate = DateTime.Now;
            this.lastUpdateDate = DateTime.Now;
            this.directory = directory;
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

        public DateTime LastUpdateDate
        {
            get => this.lastUpdateDate;
        }

        public Directory Directory
        {
            get => this.directory;
            set => this.directory = value;
        }

        public void UpdateFile()
        {
            this.lastUpdateDate = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"File name: {this.name}");
            sb.AppendLine($"Creation date: {this.creationDate.ToString("MM/dd/yyyy H:mm")}");
            sb.AppendLine($"Last update date: {this.lastUpdateDate.ToString("MM/dd/yyyy H:mm")}");

            return sb.ToString();
        }
    }
}
