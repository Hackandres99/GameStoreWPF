using System.Collections.Generic;
using System.ComponentModel;

namespace GameStoreWPF.Models
{
	public partial class ConsoleVideoGame : INotifyPropertyChanged
	{
		private int _id;
		private string? _name;

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

		public string? Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					OnPropertyChanged(nameof(Name));
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



