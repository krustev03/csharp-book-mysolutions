using System;
using System.Collections.Generic;
using System.Text;

namespace _04.AudioSystem
{
    public class Song
    {
        private string name;
        private TimeSpan duration;

        public Song(string name, string duration)
        {
            this.name = name;
            this.duration = TimeSpan.ParseExact(duration, @"m\:ss", null);
        }

        public override string ToString()
        {
            return $"{this.name} - {this.duration.ToString(@"mm\:ss")}";
        }
    }
}
