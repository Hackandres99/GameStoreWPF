using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Adds
{
	public class ConsoleAddedEvent
	{
		public ConsoleVideoGame NewConsole { get; }
		public ConsoleAddedEvent(ConsoleVideoGame console)
		{
			NewConsole = console;
		}
	}
}
