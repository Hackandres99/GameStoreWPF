using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Updates
{
	public class TypeUpdatedEvent
	{
		public VideoGameType UpdatedType { get; }
		public TypeUpdatedEvent(VideoGameType type)
		{
			UpdatedType = type;
		}
	}
}
