using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Context;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWPF.Services.Implementations
{
	public class TypeService: ITypeService
	{
		private GameStoreContext _context;
		public TypeService(GameStoreContext context) 
		{
			_context = context;
		}

		public async Task<VideoGameType> CreateVideoGameTypeAsync(VideoGameType videoGameType)
		{
			var type = await _context.VideoGameTypes.AddAsync(videoGameType);
			await _context.SaveChangesAsync();
			return type.Entity;
		}

		public async Task<bool> DeleteVideoGameTypeAsync(int id)
		{
			var type = await _context.VideoGameTypes.FindAsync(id);
			if (type == null) return false;
			_context.VideoGameTypes.Remove(type);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<VideoGameType> GetVideoGameTypeAsync(int id)
		{
			return await _context.VideoGameTypes.FindAsync(id);
		}

		public async Task<List<VideoGameType>> GetVideoGameTypesAsync()
		{
			return await _context.VideoGameTypes.ToListAsync();
		}

		public async Task<VideoGameType> UpdateVideoGameTypeAsync(VideoGameType videoGameType)
		{
			var typeUpdated = _context.VideoGameTypes.Update(videoGameType);
			await _context.SaveChangesAsync();
			return typeUpdated.Entity;
		}
	}
}
