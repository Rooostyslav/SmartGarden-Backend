using Microsoft.EntityFrameworkCore;
using SmartGarden.DAL.EF;
using SmartGarden.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
	{
		private readonly SmartGardenContext smartGardenContext;

		public Repository(SmartGardenContext smartGardenContext)
		{
			this.smartGardenContext = smartGardenContext;
		}

		public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
		{
			IQueryable<TEntity> entities = smartGardenContext.Set<TEntity>();

			if (predicate != null)
			{
				entities = entities.Where(predicate);
			}

			return await entities.ToListAsync();
		}

		public async Task<TEntity> FindByIdAsync(object id)
		{
			return await smartGardenContext.FindAsync<TEntity>(id);
		}

		public async Task AddAsync(TEntity entity)
		{
			await smartGardenContext.AddAsync(entity);
		}

		public void Update(TEntity entityToUpdate)
		{
			smartGardenContext.Update(entityToUpdate);
		}

		public async Task DeleteAsync(object id)
		{
			var entityToDelete = await FindByIdAsync(id);
			if (entityToDelete != null)
			{
				Delete(entityToDelete);
			}
		}

		public void Delete(TEntity entityToDelete)
		{
			smartGardenContext.Remove(entityToDelete);
		}
	}
}
