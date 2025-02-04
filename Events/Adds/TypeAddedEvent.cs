using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Adds
{
	public class TypeAddedEvent
	{
		public VideoGameType NewType { get; }
		public TypeAddedEvent(VideoGameType type)
		{
			NewType = type;
		}
	}
}
