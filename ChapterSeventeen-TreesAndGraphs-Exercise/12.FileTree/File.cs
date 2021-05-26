namespace _12.FileTree
{
    public class File
    {
        private string name;
        private long size;

        public File()
        {
        }

        public File(string name, long size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name 
        {
            get => this.name;
            set => this.name = value;
        }

        public long Size
        {
            get => this.size;
            set => this.size = value;
        }
    }
}
