using System;
using System.Text;

namespace _04.RealFileSystem
{
    public class TextFile : File
    {
        private string content;

        public TextFile(string name, DateTime creationDate, DateTime lastUpdateDate, Directory directory, string content)
            : base(name, creationDate, lastUpdateDate, directory)
        {
            this.content = content;
        }

        public string Content
        {
            get => this.content;
            set => this.content = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.Append($"Content: {this.content}");

            return sb.ToString();
        }
    }
}
