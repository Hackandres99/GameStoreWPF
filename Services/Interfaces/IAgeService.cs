using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Models;

namespace GameStoreWPF.Services.Interfaces
{
	public interface IAgeService
	{
		Task<List<VideoGameAge>> GetVideoGameAgesAsync();
		Task<VideoGameAge> GetVideoGameAgeAsync(int id);
		Task<Boolean> DeleteVideoGameAgeAsync(int id);
		Task<VideoGameAge> CreateVideoGameAgeAsync(VideoGameAge videoGameAge);
		Task<VideoGameAge> UpdateVideoGameAgeAsync(VideoGameAge videoGameAge);
	}
}
