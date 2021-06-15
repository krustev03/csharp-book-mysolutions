using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.FileSystem
{
    public class Device
    {
        private string name;
        private Directory directoryTree;

        public Device(string name, Directory directoryTree)
        {
            this.name = name;
            this.directoryTree = directoryTree;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public Directory DirectoryTree
        {
            get => this.directoryTree;
            set => this.directoryTree = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Device name: {this.name}");
            sb.AppendLine($"Directory Tree:");
            sb.AppendLine($" {directoryTree}");

            return sb.ToString();
        }
    }
}
