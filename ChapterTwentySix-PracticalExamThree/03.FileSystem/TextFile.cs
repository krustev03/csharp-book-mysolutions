using System.Text;

namespace _03.FileSystem
{
    public class TextFile : File
    {
        private string content;

        public TextFile(string name, Directory directory, string content)
            : base(name, directory)
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
