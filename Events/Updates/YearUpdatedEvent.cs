using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Updates
{
	public class YearUpdatedEvent
	{
		public PublicationYear UpdatedYear { get; }
		public YearUpdatedEvent(PublicationYear year)
		{
			UpdatedYear = year;
		}
	}
}


