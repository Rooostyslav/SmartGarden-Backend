using SmartGarden.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Interfaces
{
	public interface IPlantRepository
	{
		Task<IEnumerable<Plant>> FindWithIncludesAsync(Expression<Func<Plant, bool>> predicate);

		Task<IEnumerable<Plant>> FindAsync(Expression<Func<Plant, bool>> predicate);

		Task<Plant> FindByIdAsync(object id);

		Task AddAsync(Plant plant);

		void Update(int id, Plant plantToUpddate);

		Task DeleteAsync(object id);
	}
}
