using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Models;

namespace GameStoreWPF.Services.Interfaces
{
	public interface ITypeService
	{
		Task<List<VideoGameType>> GetVideoGameTypesAsync();
		Task<VideoGameType> GetVideoGameTypeAsync(int id);
		Task<Boolean> DeleteVideoGameTypeAsync(int id);
		Task<VideoGameType> CreateVideoGameTypeAsync(VideoGameType videoGameType);
		Task<VideoGameType> UpdateVideoGameTypeAsync(VideoGameType videoGameType);
	}
}
