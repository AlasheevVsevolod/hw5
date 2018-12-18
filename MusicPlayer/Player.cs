using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
	public class Player
	{
		const int MIN_VOLUME = 0;
		const int MAX_VOLUME = 100;

		private bool _locked;

		private bool _playing;

		private int _volume;
		public int Volume
		{
			get
			{
				return _volume;
			}

			private set
			{
				if (value < MIN_VOLUME)
				{
					_volume = MIN_VOLUME;
				}
				else if (value > MAX_VOLUME)
				{
					_volume = MAX_VOLUME;
				}
				else
				{
					_volume = value;
				}
			}
		}

		public Song[] Songs;

		public void VolumeUp()
		{
			Volume++;
			Console.WriteLine($"Громкость увеличена. {_volume}%");
		}

		public void VolumeDown()
		{
			Volume--;
			Console.WriteLine($"Громкость уменьшена. {_volume}%");
		}

		public void VolumeChange( int step)
		{
			Volume += step;
			if (step > 0)
			{
				Console.WriteLine($"Громкость увеличена. {_volume}%");
			}
			else
			{
				Console.WriteLine($"Громкость уменьшена. {_volume}%");
			}
		}

		public bool Start()
		{
			_playing = true;
			Console.WriteLine($"Воспроизведение: {Songs[0].Name}");
			return _playing;
		}

		public bool Stop()
		{
			_playing = false;
			Console.WriteLine("Пауза");
			return _playing;
		}

		public void Lock()
		{
			_locked = true;
			Console.WriteLine("Плеер заблокирован");
		}

		public void Unlock()
		{
			_locked = false;
			Console.WriteLine("Плеер разблокирован");
		}
	}
}
