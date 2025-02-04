using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Updates
{
	public class AgeUpdatedEvent
	{
		public VideoGameAge UpdatedAge { get; }
		public AgeUpdatedEvent(VideoGameAge age)
		{
			UpdatedAge = age;
		}
	}
}
