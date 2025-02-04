using System.Collections.Generic;
using System.ComponentModel;

namespace GameStoreWPF.Models
{
	public partial class VideoGameAge : INotifyPropertyChanged
	{
		private int _id;
		private int? _age;

		public int Id
		{
			get => _id;
			set
			{
				if (_id != value)
				{
					_id = value;
					OnPropertyChanged(nameof(Id));
				}
			}
		}

		public int? Age
		{
			get => _age;
			set
			{
				if (_age != value)
				{
					_age = value;
					OnPropertyChanged(nameof(Age));
				}
			}
		}

		public virtual ICollection<VideoGame> VideoGames { get; set; } = new List<VideoGame>();

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

