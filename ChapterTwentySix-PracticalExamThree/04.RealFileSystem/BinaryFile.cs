using System;
using System.Text;

namespace _04.RealFileSystem
{
    public class BinaryFile : File
    {
        private byte[] content;

        public BinaryFile(string name, DateTime creationDate, DateTime lastUpdateDate, Directory directory, byte[] content)
             : base(name, creationDate, lastUpdateDate, directory)
        {
            this.content = content;
        }

        public byte[] Content
        {
            get => this.content;
            set => this.content = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.Append($"Content: {String.Join(string.Empty, this.content)}");

            return sb.ToString();
        }
    }
}
