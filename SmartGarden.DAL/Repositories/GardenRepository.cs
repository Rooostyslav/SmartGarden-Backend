using Microsoft.EntityFrameworkCore;
using SmartGarden.DAL.EF;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Repositories
{
	public class GardenRepository : Repository<Garden>, IGardenRepository
	{
		private readonly DbSet<Garden> garden;

		public GardenRepository(SmartGardenContext smartGardenContext)
			: base(smartGardenContext)
		{
			garden = smartGardenContext.Gardens;
		}

		public async Task<IEnumerable<Garden>> FindWithIncludesAsync(Expression<Func<Garden, bool>> predicate)
		{
			IQueryable<Garden> gardenQuery = garden
				.Include(g => g.Plants)
				.Include(g => g.Resources)
				.Include(g => g.User);

			if (predicate != null)
			{
				gardenQuery = gardenQuery.Where(predicate);
			}

			return await gardenQuery.ToListAsync();
		}
	}
}
