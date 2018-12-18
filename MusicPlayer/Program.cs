using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
	class Program
	{
		static void Main(string[] args)
		{
			var player = new Player();
//			player.Volume = 20;
			player.Songs = GetSongsData();

//			TraceInfo(player);

			player.Start();
			player.VolumeUp();
			player.VolumeDown();

			player.VolumeChange(-300);
			player.VolumeChange(300);

			player.Lock();
			player.Unlock();

			//player.Playing = false;
			Console.WriteLine(player.Playing ? "Player is playing": "Player is stopped");

			player.Stop();
			Console.WriteLine(player.Playing ? "Player is playing" : "Player is stopped");

			Console.ReadLine();
		}

		public static Song[] GetSongsData()
		{
			var artist = new Artist();
			artist.Name = "Powerwolf";
			artist.Genre = "Metal";
			Console.WriteLine($"Artist1 {artist.Name}");
			Console.WriteLine($"Genre1 {artist.Genre}\n");

			var artist2 = new Artist("Lordi");
			Console.WriteLine($"Artist2 {artist2.Name}");
			Console.WriteLine($"Genre2 {artist2.Genre}\n");

			var artist3 = new Artist("Sabaton", "Rock");
			Console.WriteLine($"Artist3 {artist3.Name}");
			Console.WriteLine($"Genre3 {artist3.Genre}\n");

			var album = new Album();
			album.Name = "New Album";
			album.Year = 2018;

			var song = new Song()
			{
				Duration = 100,
				Name = "New song",
				Album = album,
				Artist = artist
			};

			return new Song[] {song};
		}

		public static void TraceInfo(Player player)
		{
			Console.WriteLine(player.Songs[0].Artist.Name);
			Console.WriteLine(player.Songs[0].Duration);
			Console.WriteLine(player.Songs.Length);
			Console.WriteLine(player.Volume);
		}
	}
}
