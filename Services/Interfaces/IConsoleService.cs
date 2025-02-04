using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Models;

namespace GameStoreWPF.Services.Interfaces
{
	public interface IConsoleService
	{
		Task<List<ConsoleVideoGame>> GetConsoleVideoGamesAsync();
		Task<ConsoleVideoGame> GetConsoleVideoGameAsync(int id);
		Task<Boolean> DeleteConsoleVideoGameAsync(int id);
		Task<ConsoleVideoGame> CreateConsoleVideoGameAsync(ConsoleVideoGame consoleVideoGame);
		Task<ConsoleVideoGame> UpdateConsoleVideoGameAsync(ConsoleVideoGame consoleVideoGame);
	}
}
