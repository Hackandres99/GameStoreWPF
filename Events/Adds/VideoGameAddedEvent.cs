using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Adds
{
	public class VideoGameAddedEvent
	{
		public VideoGame NewVideoGame { get; }

		public VideoGameAddedEvent(VideoGame newVideoGame)
		{
			NewVideoGame = newVideoGame;
		}
	}
}
