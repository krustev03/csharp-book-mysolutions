using System;
using System.Collections.Generic;
using System.Text;

namespace _12.FileTree
{
    public class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder()
        {
        }

        public Folder(string name)
        {
            this.name = name;
        }

        public Folder(string name, File[] files, Folder[] childFolders)
        {
            this.name = name;
            this.files = files;
            this.childFolders = childFolders;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public File[] Files
        {
            get => this.files;
            set => this.files = value;
        }

        public Folder[] ChildFolders
        {
            get => this.childFolders;
            set => this.childFolders = value;
        }
    }
}
