using System.Collections.Generic;
using System.Threading.Tasks;
using GameStoreWPF.Context;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWPF.Services.Implementations
{
	public class PublicationService: IPublicationService
	{
		private GameStoreContext _context;

		public PublicationService(GameStoreContext context) 
		{
			_context = context;
		}

		public async Task<PublicationYear> CreatePublicationYearAsync(PublicationYear publicationYear)
		{
			var publication = await _context.PublicationYears.AddAsync(publicationYear);
			await _context.SaveChangesAsync();
			return publication.Entity;
		}

		public async Task<bool> DeletePublicationYearAsync(int id)
		{
			var publication = await _context.PublicationYears.FindAsync(id);
			if (publication == null) return false;
			_context.PublicationYears.Remove(publication);
			await _context.SaveChangesAsync();
			return true;

		}

		public async Task<PublicationYear> GetPublicationYearAsync(int id)
		{
			return await _context.PublicationYears.FindAsync(id);
		}

		public async Task<List<PublicationYear>> GetPublicationYearsAsync()
		{
			return await _context.PublicationYears.ToListAsync();
		}

		public async Task<PublicationYear> UpdatePublicationYearAsync(PublicationYear publicationYear)
		{
			var publicationUpdated = _context.PublicationYears.Update(publicationYear);
			await _context.SaveChangesAsync();
			return publicationUpdated.Entity;
		}
	}
}
