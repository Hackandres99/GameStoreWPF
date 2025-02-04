using System.Collections.Generic;
using System.ComponentModel;

namespace GameStoreWPF.Models
{
	public partial class VideoGameType : INotifyPropertyChanged
	{
		private int _id;
		private string? _type;

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

		public string? Type
		{
			get => _type;
			set
			{
				if (_type != value)
				{
					_type = value;
					OnPropertyChanged(nameof(Type));
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

