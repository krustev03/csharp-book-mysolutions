using System;
using System.Collections.Generic;
using System.Text;

namespace _04.AudioSystem
{
    public class MusicCompany
    {
        private string name;
        private string adress;
        private string ownerName;
        private List<Singer> singers;

        public MusicCompany(string name, string adress, string ownerName)
        {
            this.name = name;
            this.adress = adress;
            this.ownerName = ownerName;
            this.singers = new List<Singer>();
        }

        public void AddSinger(Singer singer)
        {
            this.singers.Add(singer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"### {this.name} ###");
            sb.AppendLine($" ### Adress: {this.adress} ###");
            sb.AppendLine($" ### Owner: {this.ownerName} ###");
            sb.AppendLine($" ### Singers ###");

            foreach (var singer in this.singers)
            {
                sb.AppendLine($" {singer}");
            }

            return sb.ToString();
        }
    }
}
