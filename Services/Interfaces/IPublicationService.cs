using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Models;

namespace GameStoreWPF.Services.Interfaces
{
	public interface IPublicationService
	{
		Task<List<PublicationYear>> GetPublicationYearsAsync();
		Task<PublicationYear> GetPublicationYearAsync(int id);
		Task<Boolean> DeletePublicationYearAsync(int id);
		Task<PublicationYear> CreatePublicationYearAsync(PublicationYear publicationYear);
		Task<PublicationYear> UpdatePublicationYearAsync(PublicationYear publicationYear);
	}
}
