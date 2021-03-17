using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Action = SmartGarden.DAL.Entity.Action;

namespace SmartGarden.DAL.Interfaces
{
	public interface IActionRepository
	{
		Task<IEnumerable<Action>> FindWithIncludesAsync(Expression<Func<Action, bool>> predicate);

		Task<IEnumerable<Action>> FindAsync(Expression<Func<Action, bool>> predicate);

		Task<Action> FindByIdAsync(object id);

		Task AddAsync(Action action);

		void Update(Action actionToUpddate);

		Task DeleteAsync(object id);
	}
}
