using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Models;

namespace GameStoreWPF.Services.Interfaces
{
	public interface IVideoGameService
	{
		Task<List<VideoGame>> GetVideoGamesAsync();
		Task<VideoGame> GetVideoGameAsync(int id);
		Task<List<VideoGame>> GetBySearchParameters(int? console, int? year, int? type, int? age);
		Task<Boolean> DeleteVideoGameAsync(int id);
		Task<VideoGame> CreateVideoGameAsync(VideoGame videoGame);
		Task<VideoGame> UpdateVideoGameAsync(VideoGame videoGame);
	}
}
