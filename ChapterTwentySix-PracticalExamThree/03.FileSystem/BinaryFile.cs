using System;
using System.Collections.Generic;
using System.Text;

namespace _03.FileSystem
{
    public class BinaryFile : File
    {
        private byte[] content;

        public BinaryFile(string name, Directory directory, byte[] content)
            : base(name, directory)
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
