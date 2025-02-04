using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Adds
{
	public class YearAddedEvent
	{
		public PublicationYear NewYear { get; }
		public YearAddedEvent(PublicationYear year)
		{
			NewYear = year;
		}
	}
}
