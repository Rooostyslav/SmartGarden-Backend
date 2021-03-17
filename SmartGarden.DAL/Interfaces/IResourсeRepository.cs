using SmartGarden.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Interfaces
{
	public interface IResourсeRepository
	{
		Task<IEnumerable<Resource>> FindWithIncludesAsync(Expression<Func<Resource, bool>> predicate);

		Task<IEnumerable<Resource>> FindAsync(Expression<Func<Resource, bool>> predicate);

		Task<Resource> FindByIdAsync(object id);

		Task AddAsync(Resource resource);

		void Update(Resource resourceToUpddate);

		Task DeleteAsync(object id);
	}
}
