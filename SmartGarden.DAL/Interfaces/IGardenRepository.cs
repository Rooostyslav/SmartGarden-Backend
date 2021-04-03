using SmartGarden.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Interfaces
{
	public interface IGardenRepository
	{
		Task<IEnumerable<Garden>> FindWithIncludesAsync(Expression<Func<Garden, bool>> predicate);

		Task<IEnumerable<Garden>> FindAsync(Expression<Func<Garden, bool>> predicate);

		Task<Garden> FindByIdAsync(object id);

		Task AddAsync(Garden garden);

		void Update(int id, Garden gardenToUpddate);

		Task DeleteAsync(object id);
	}
}
