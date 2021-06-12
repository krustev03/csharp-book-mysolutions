using System;
using _04.AudioSystem.Enums;

namespace _04.AudioSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song1 = new Song("Geavy Metal", "1:43");
            Song song2 = new Song("Come and get it", "2:09");

            Album album1 = new Album("My Album", Genre.Rap, 2003);
            album1.Sell();
            album1.Sell();
            album1.AddSong(song1);
            album1.AddSong(song2);

            Song song3 = new Song("Dogs Out", "1:12");
            Song song4 = new Song("Cats In", "2:46");

            Album album2 = new Album("Your Album", Genre.Classical, 2020);
            album2.AddSong(song3);
            album2.AddSong(song4);

            Singer singer1 = new Singer("Petar", "Skalata");
            singer1.AddAlbum(album1);
            singer1.AddAlbum(album2);

            Singer singer2 = new Singer("Stoyan Kolev", "Hektor");

            MusicCompany musicCompany = new MusicCompany("My Company", "Stamen Iliev 26", "Petar Krastev");
            musicCompany.AddSinger(singer1);
            musicCompany.AddSinger(singer2);

            Console.WriteLine(musicCompany);
        }
    }
}
