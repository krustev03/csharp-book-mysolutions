using System;
using System.Collections.Generic;
using System.Text;

namespace _04.AudioSystem
{
    public class Singer
    {
        private string name;
        private string nickname;
        private List<Album> albums;

        public Singer(string name, string nickname)
        {
            this.name = name;
            this.nickname = nickname;
            this.albums = new List<Album>();
        }

        public void AddAlbum(Album album)
        {
            this.albums.Add(album);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" ~~~ Name: {this.name} ~~~");
            sb.AppendLine($"  ~~~ Nickname: {this.nickname} ~~~");
            sb.AppendLine($"  ~~~ Albums ~~~");

            foreach (var album in this.albums)
            {
                sb.AppendLine($"  {album}");
            }

            return sb.ToString();
        }
    }
}
