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
	public class PlantRepository : Repository<Plant>, IPlantRepository
	{
		private readonly DbSet<Plant> plants;

		public PlantRepository(SmartGardenContext smartGardenContext)
			: base(smartGardenContext)
		{
			plants = smartGardenContext.Plants;
		}

		public async Task<IEnumerable<Plant>> FindWithIncludesAsync(Expression<Func<Plant, bool>> predicate)
		{
			IQueryable<Plant> plantQuery = plants.Include(p => p.Garden).Include(p => p.Actions);

			if (predicate != null)
			{
				plantQuery = plantQuery.Where(predicate);
			}

			return await plantQuery.ToListAsync();
		}
	}
}
