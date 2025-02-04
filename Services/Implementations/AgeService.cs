using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Context;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWPF.Services.Implementations
{
	public class AgeService: IAgeService
	{
		private GameStoreContext _context;
		public AgeService(GameStoreContext context) 
		{
			_context = context;
		}

		public async Task<VideoGameAge> CreateVideoGameAgeAsync(VideoGameAge videoGameAge)
		{
			var age = await _context.VideoGameAges.AddAsync(videoGameAge);
			await _context.SaveChangesAsync();
			return age.Entity;
		}

		public async Task<bool> DeleteVideoGameAgeAsync(int id)
		{
			var age = await _context.VideoGameAges.FindAsync(id);
			if (age == null) return false;
			_context.VideoGameAges.Remove(age);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<VideoGameAge> GetVideoGameAgeAsync(int id)
		{
			return await _context.VideoGameAges.FindAsync(id);
		}

		public async Task<List<VideoGameAge>> GetVideoGameAgesAsync()
		{
			return await _context.VideoGameAges.ToListAsync();
		}

		public async Task<VideoGameAge> UpdateVideoGameAgeAsync(VideoGameAge videoGameAge)
		{
			var ageUpdated = _context.VideoGameAges.Update(videoGameAge);
			await _context.SaveChangesAsync();
			return ageUpdated.Entity;
		}
	}
}
