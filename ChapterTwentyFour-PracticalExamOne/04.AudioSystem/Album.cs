using _04.AudioSystem.Enums;
using System.Collections.Generic;
using System.Text;

namespace _04.AudioSystem
{
    public class Album
    {
        private string name;
        private Genre genre;
        private int yearOfPublishing;
        private int countOfSoldCopies;
        private List<Song> songs;

        public Album(string name, Genre genre, int yearOfPublishing)
        {
            this.name = name;
            this.genre = genre;
            this.yearOfPublishing = yearOfPublishing;
            this.songs = new List<Song>();
        }

        public void Sell()
        {
            this.countOfSoldCopies++;
        }

        public void AddSong(Song song)
        {
            this.songs.Add(song);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" --- {this.name} ---");
            sb.AppendLine($"    -- Year Of Publishing: {this.yearOfPublishing} --");
            sb.AppendLine($"    -- Genre: {this.genre} --");
            sb.AppendLine($"    -- Copies Sold: {this.countOfSoldCopies} --");
            sb.AppendLine($"    -- Songs --");

            for (int i = 0; i < this.songs.Count; i++)
            {
                sb.AppendLine($"       |{i + 1}.{this.songs[i]}|");
            }

            return sb.ToString();
        }
    }
}
