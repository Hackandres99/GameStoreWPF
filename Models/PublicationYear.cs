using System.Collections.Generic;
using System.ComponentModel;

namespace GameStoreWPF.Models
{
	public partial class PublicationYear : INotifyPropertyChanged
	{
		private int _id;
		private int? _year;

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

		public int? Year
		{
			get => _year;
			set
			{
				if (_year != value)
				{
					_year = value;
					OnPropertyChanged(nameof(Year));
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

