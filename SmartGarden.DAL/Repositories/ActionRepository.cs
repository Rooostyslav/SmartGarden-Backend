using Microsoft.EntityFrameworkCore;
using SmartGarden.DAL.EF;
using SmartGarden.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Action = SmartGarden.DAL.Entity.Action;

namespace SmartGarden.DAL.Repositories
{
	public class ActionRepository : Repository<Action>, IActionRepository
	{
		private readonly DbSet<Action> actions;

		public ActionRepository(SmartGardenContext smartGardenContext)
			: base(smartGardenContext)
		{
			actions = smartGardenContext.Actions;
		}

		public async Task<IEnumerable<Action>> FindWithIncludesAsync(Expression<Func<Action, bool>> predicate)
		{
			IQueryable<Action> actionQuery = actions.Include(a => a.Plant);

			if (predicate != null)
			{
				actionQuery = actionQuery.Where(predicate);
			}

			return await actionQuery.ToListAsync();
		}
	}
}
