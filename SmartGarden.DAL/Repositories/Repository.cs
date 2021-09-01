using Microsoft.EntityFrameworkCore;
using SmartGarden.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private SmartGardenContext _context;
		private DbSet<TEntity> _dbSet;

		public Repository(SmartGardenContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync(
			Expression<Func<TEntity, bool>> filter = null, 
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
			string includeProperties = "")
		{
			IQueryable<TEntity> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}

			return await query.ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(object id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<TEntity> InsertAsync(TEntity entity)
		{
			var added = await _dbSet.AddAsync(entity);
			return added.Entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
		{
			var updated = _dbSet.Attach(entityToUpdate);
			_context.Entry(entityToUpdate).State = EntityState.Modified;

			await Task.CompletedTask;
			return updated.Entity;
		}

		public async Task<TEntity> DeleteAsync(object id)
		{
			TEntity entityToDelete = await _dbSet.FindAsync(id);
			return await DeleteAsync(entityToDelete);
		}

		public async Task<TEntity> DeleteAsync(TEntity entityToDelete)
		{
			if (_context.Entry(entityToDelete).State == EntityState.Detached)
			{
				_dbSet.Attach(entityToDelete);
			}

			var deleted = _dbSet.Remove(entityToDelete);
			await Task.CompletedTask;
			return deleted.Entity;
		}
	}
}
