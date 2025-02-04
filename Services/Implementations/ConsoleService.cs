using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Context;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWPF.Services.Implementations
{
	public class ConsoleService : IConsoleService
	{
		private GameStoreContext _context;

		public ConsoleService(GameStoreContext context)
		{
			_context = context;
		}

		public async Task<ConsoleVideoGame> CreateConsoleVideoGameAsync(ConsoleVideoGame consoleVideoGame)
		{
			var console = await _context.ConsoleVideoGames.AddAsync(consoleVideoGame);
			await _context.SaveChangesAsync();
			return console.Entity;
		}

		public async Task<bool> DeleteConsoleVideoGameAsync(int id)
		{
			var console = await _context.ConsoleVideoGames.FindAsync(id);
			if (console == null) return false;
			_context.ConsoleVideoGames.Remove(console);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<ConsoleVideoGame> GetConsoleVideoGameAsync(int id)
		{
			return await _context.ConsoleVideoGames.FindAsync(id);
		}

		public async Task<List<ConsoleVideoGame>> GetConsoleVideoGamesAsync()
		{
			return await _context.ConsoleVideoGames.ToListAsync();
		}

		public async Task<ConsoleVideoGame> UpdateConsoleVideoGameAsync(ConsoleVideoGame consoleVideoGame)
		{
			var consoleUpdated = _context.ConsoleVideoGames.Update(consoleVideoGame);
			await _context.SaveChangesAsync();
			return consoleUpdated.Entity;
		}
	}
}
