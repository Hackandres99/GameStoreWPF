using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreWPF.Context;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWPF.Services.Implementations
{
	public class VideoGameService: IVideoGameService
	{
		private GameStoreContext _context;

		public VideoGameService(GameStoreContext context)
		{
			_context = context;
		}

		public async Task<VideoGame> CreateVideoGameAsync(VideoGame videoGame)
		{
			var game = await _context.VideoGames.AddAsync(videoGame);
			await _context.SaveChangesAsync();
			return game.Entity;
		}

		public async Task<bool> DeleteVideoGameAsync(int id)
		{
			var game = await _context.VideoGames.FindAsync(id);
			if (game == null) return false;
			_context.VideoGames.Remove(game);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<List<VideoGame>> GetBySearchParameters(
			int? console = null, int? year = null, int? type = null, int? age = null)
		{
			var query = _context.VideoGames.AsQueryable();

			if (console.HasValue)
				query = query.Where(v => v.Console == console.Value);

			if (year.HasValue)
				query = query.Where(v => v.PublicationYear == year.Value);

			if (type.HasValue)
				query = query.Where(v => v.VideoGameType == type.Value);

			if (age.HasValue)
				query = query.Where(v => v.VideoGameAge == age.Value);

			return await query.ToListAsync();
		}


		public async Task<VideoGame> GetVideoGameAsync(int id)
		{
			return await _context.VideoGames.FindAsync(id);
		}

		public async Task<List<VideoGame>> GetVideoGamesAsync()
		{
			return await _context.VideoGames.ToListAsync();
		}

		public async Task<VideoGame> UpdateVideoGameAsync(VideoGame videoGame)
		{
			var gameUpdated = _context.VideoGames.Update(videoGame);
			await _context.SaveChangesAsync();
			return gameUpdated.Entity;
		}
	}
}
