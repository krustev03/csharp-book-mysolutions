using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.RealFileSystem
{
    public class ComputerStorage
    {
        private string name;
        private List<Device> devices;

        public ComputerStorage(string name)
        {
            this.name = name;
            this.devices = new List<Device>();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public List<Device> Devices
        {
            get => this.devices;
            set => this.devices = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Computer storage name: {this.name}");
            sb.AppendLine("Devices:");

            foreach (var device in this.devices)
            {
                sb.AppendLine($"{String.Join(Environment.NewLine, device.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(line => " " + line))}\n");
            }

            return sb.ToString();
        }
    }
}
