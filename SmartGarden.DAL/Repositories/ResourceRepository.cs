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
	public class ResourceRepository : Repository<Resource>, IResourсeRepository
	{
		private readonly DbSet<Resource> resources;

		public ResourceRepository(SmartGardenContext smartGardenContext)
			: base(smartGardenContext)
		{
			resources = smartGardenContext.Resources;
		}

		public async Task<IEnumerable<Resource>> FindWithIncludesAsync(Expression<Func<Resource, bool>> predicate)
		{
			IQueryable<Resource> resourceQuery = resources.Include(r => r.Garden);

			if (predicate != null)
			{
				resourceQuery = resourceQuery.Where(predicate);
			}

			return await resourceQuery.ToListAsync();
		}
	}
}
