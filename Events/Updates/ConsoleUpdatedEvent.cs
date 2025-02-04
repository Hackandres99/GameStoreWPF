using GameStoreWPF.Models;

namespace GameStoreWPF.Events.Updates
{
	public class ConsoleUpdatedEvent
	{
		public ConsoleVideoGame UpdatedConsole { get; }
		public ConsoleUpdatedEvent(ConsoleVideoGame console)
		{
			UpdatedConsole = console;
		}
	}
}
