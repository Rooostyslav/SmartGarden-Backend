using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

		Task<TEntity> FindByIdAsync(object id);

		Task AddAsync(TEntity entity);

		void Update(int id, TEntity entityToUpdate);

		Task DeleteAsync(object id);

		void Delete(TEntity entityToDelete);
	}
}
