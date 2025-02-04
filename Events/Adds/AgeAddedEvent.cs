using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Adds
{
	public class AgeAddedEvent
	{
		public VideoGameAge NewAge { get; }
		public AgeAddedEvent(VideoGameAge age)
		{
			NewAge = age;
		}
	}
}
