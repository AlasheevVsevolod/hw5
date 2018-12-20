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
//task1
			var player = new Player();

//task2
//			player.Volume = 20;
			player.Songs = GetSongsData();

//			TraceInfo(player);

//task3
//task4
			player.VolumeUp();
			player.VolumeDown();

			player.VolumeChange(-300);
			player.VolumeChange(300);

			player.Lock();
			player.Unlock();

			player.Start();
			//player.Playing = false;
			Console.WriteLine(player.Playing ? "Player is playing": "Player is stopped");

			player.Stop();
			Console.WriteLine(player.Playing ? "Player is playing" : "Player is stopped\n");

//task6
			Song newsong = CreateDefaultSong();
			Console.WriteLine($"Album name {newsong.Album.Name}");
			Console.WriteLine($"Album year {newsong.Album.Year}");
			Console.WriteLine($"Artist genre {newsong.Artist.Genre}");
			Console.WriteLine($"Artist name {newsong.Artist.Name}");
			Console.WriteLine($"Song duration {newsong.Duration}");
			Console.WriteLine($"Song name {newsong.Name}\n");

			Song newsong_copy = CreateDefaultSong2();
			Console.WriteLine($"Album name {newsong_copy.Album.Name}");
			Console.WriteLine($"Album year {newsong_copy.Album.Year}");
			Console.WriteLine($"Artist genre {newsong_copy.Artist.Genre}");
			Console.WriteLine($"Artist name {newsong_copy.Artist.Name}");
			Console.WriteLine($"Song duration {newsong_copy.Duration}");
			Console.WriteLine($"Song name {newsong_copy.Name}\n");
			
			Song newsong2 = CreateNamedSong("Sahti");
			Console.WriteLine($"Album name {newsong2.Album.Name}");
			Console.WriteLine($"Album year {newsong2.Album.Year}");
			Console.WriteLine($"Artist genre {newsong2.Artist.Genre}");
			Console.WriteLine($"Artist name {newsong2.Artist.Name}");
			Console.WriteLine($"Song duration {newsong2.Duration}");
			Console.WriteLine($"Song name {newsong2.Name}\n");

			Song newsong3 = CreateSong("Uptown Funk", 123, "Bruno Mars", "Dancing", "Funk", 2014);
			Console.WriteLine($"Album name {newsong3.Album.Name}");
			Console.WriteLine($"Album year {newsong3.Album.Year}");
			Console.WriteLine($"Artist genre {newsong3.Artist.Genre}");
			Console.WriteLine($"Artist name {newsong3.Artist.Name}");
			Console.WriteLine($"Song duration {newsong3.Duration}");
			Console.WriteLine($"Song name {newsong3.Name}\n");

//task7
			int TheShortestSong, TheLongestSong = 0, RandomDuration;
			string ShortestSongName = "Shortest song ever";
//			RandomDuration = TotalSongsDuration(out TheShortestSong, ref TheLongestSong, ref ShortestSongName);
			TotalSongsDuration(out TheShortestSong, ref TheLongestSong, ref ShortestSongName, out RandomDuration);

			Console.Write("Длина пяти случайно сгенерированных песен = ");
			Console.WriteLine($"{RandomDuration}с или {RandomDuration / 60}м {RandomDuration % 60}с");
			Console.WriteLine($"Самая короткая песня длится {TheShortestSong}с");
			Console.WriteLine($"Самая длинная песня длится {TheLongestSong}с");




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
		
		public static Song CreateDefaultSong()
		{
			Random rand = new Random();

			/*Создать строку из символов не выйдет, я так понял, т.к. строки в шарпе неизменяемые, 
поэтому имя будет одним символом*/
/*			Artist DefArtist = new Artist()
			{
				Genre = Convert.ToString((char)rand.Next((int)'A', (int)'Z')),
				Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z'))
			};
*/
/*			Album DefAlbum = new Album()
			{
				Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z')),
				Year = rand.Next(1980, DateTime.Today.Year)
			};
*/
			Song DefaultSong = new Song()
			{
				Duration = rand.Next(60, 301),
//				Album = DefAlbum,
				Album = new Album
				{
					Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z')),
					Year = rand.Next(1980, DateTime.Today.Year)
				},
//				Artist = DefArtist,
				Artist = new Artist
				{
					Genre = Convert.ToString((char)rand.Next((int)'A', (int)'Z')),
					Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z'))
				},
				Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z'))
			};

			return DefaultSong;
		}

//А если рефакторить, то можно так забомбить
		public static Song CreateDefaultSong2()
		{
/*
//параметры для примера указал
			Song DefaultSong = new Song()
			{
				DefDuration = 115,
				DefAlbum = new Album
				{
					Name = "qwe",
					Year = 2010
				},
				DefArtist = new Artist
				{
					Genre = "asd",
					Name = "zxc"
				},
				DefName = "qaz"
			};
*/
			return CreateSong("qaz", 115, "zxc", "asd", "qwe", 2010);
//короче вызвать последний метод со некоторыми рандомными(или по умолчанию) параметрами
// что смотрится гораздо приятнее
		}


		public static Song CreateNamedSong(string SongName)
		{
			Random rand = new Random();

			Song NamedSong = new Song()
			{
				Duration = rand.Next(60, 301),
				Album = new Album()
				{
					Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z')),
					Year = rand.Next(1980, DateTime.Today.Year)
				},
				Artist = new Artist()
				{
					Genre = Convert.ToString((char)rand.Next((int)'A', (int)'Z')),
					Name = Convert.ToString((char)rand.Next((int)'A', (int)'Z'))
				},
				Name = SongName
			};

			return NamedSong;
//а этот метод после рефакторинга тоде будет из одной строки состоять
//			return CreateSong(SongName, 115, "zxc", "asd", "qwe", 2010);
		}

		public static Song CreateSong(string SongName, int SongDuration, string ArtistName, string ArtistGenre, string AlbumName, int AlbumYear)
		{
			Song ExplicitSong = new Song()
			{
				Duration = SongDuration,
				Album = new Album()
				{
					Name = AlbumName,
					Year = AlbumYear
				},
				Artist = new Artist()
				{
					Genre = ArtistGenre,
					Name = ArtistName
				},
				Name = SongName
			};

			return ExplicitSong;
		}


//		public static int TotalSongsDuration(out int TheShortestSong, ref int TheLongestSong,
//			ref string ShortestSongName)
		public static void TotalSongsDuration(out int TheShortestSong, ref int TheLongestSong,
			ref string ShortestSongName, out int TotalDuration)
		{
//Если я всё правильно понимаю, что у нас CreateDefaultSong возвращает объект типа Song
// который уже имеет в себе объекты Album и Artist. Так что сзаново создавать и заполнять
// эти массивы не вижу смысла
			Song[] Songs = new Song[5];
//			Album[] Albums = new Album[5];
//			Artist[] Artists = new Artist[5];

//			int TotalDuration = 0, NumberOfShortestSong = 0;
			int NumberOfShortestSong = 0;
			TotalDuration = 0;


//По общему смыслу, я так понял, ref и out действуют похожим образом - передают переменную
// в вызываемый метод. Разница в том, что, используя ref, переменная уже должна иметь какое-либо
// значение, которое(именно значение переменной, не копия) может изменяться в методе.
// А при модификаторе out переменная в методе считается неинициализированной, но ей обязательно
// должно быть присвоено значение перед выходом.
// Не уверен, что это правильно, но я бы использовал ref именно для тех случаев, когда
// передаваемое значение может  меняться, а out для того, чтобы кроме переменной в return
// возвращать из метода ещё несколько значений

			TheShortestSong = 100000;

			for(int i = 0; i < Songs.Length; i++)
			{
				Songs[i] = CreateDefaultSong();
//				Albums[i] = Songs[i].Album;
//				Artists[i] = Songs[i].Artist;

				Console.WriteLine($"i = {i}");
				Console.WriteLine($"Album name {Songs[i].Album.Name}");
				Console.WriteLine($"Album year {Songs[i].Album.Year}");
				Console.WriteLine($"Artist genre {Songs[i].Artist.Genre}");
				Console.WriteLine($"Artist name {Songs[i].Artist.Name}");
				Console.WriteLine($"Song duration {Songs[i].Duration}");
				Console.WriteLine($"Song name {Songs[i].Name}\n");

				TotalDuration += Songs[i].Duration;
				if(Songs[i].Duration < TheShortestSong)
				{
					TheShortestSong = Songs[i].Duration;
					NumberOfShortestSong = i;
				}
				if(Songs[i].Duration > TheLongestSong)
				{
					TheLongestSong = Songs[i].Duration;
				}
//похоже, что Random генерирует числа как-то опираясь на таймеры, т.к. без задержки
// бывало, что два цикла генерировали одинаковые значения
				System.Threading.Thread.Sleep(10);
			}

			Songs[NumberOfShortestSong].Name = ShortestSongName;
			Console.WriteLine($"Самая коротакя песня - №{NumberOfShortestSong}");
			Console.WriteLine($"i = {NumberOfShortestSong}");
			Console.WriteLine($"Album name {Songs[NumberOfShortestSong].Album.Name}");
			Console.WriteLine($"Album year {Songs[NumberOfShortestSong].Album.Year}");
			Console.WriteLine($"Artist genre {Songs[NumberOfShortestSong].Artist.Genre}");
			Console.WriteLine($"Artist name {Songs[NumberOfShortestSong].Artist.Name}");
			Console.WriteLine($"Song duration {Songs[NumberOfShortestSong].Duration}");
			Console.WriteLine($"Song name {Songs[NumberOfShortestSong].Name}\n");

//			return TotalDuration;
		}
	}
}
