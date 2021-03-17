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
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly DbSet<User> users;

		public UserRepository(SmartGardenContext smartGardenContext)
			: base(smartGardenContext)
		{
			users = smartGardenContext.Users;
		}

		public async Task<IEnumerable<User>> FindWithIncludesAsync(Expression<Func<User, bool>> predicate)
		{
			IQueryable<User> userQuery = users.Include(u => u.Gardens);

			if (predicate != null)
			{
				userQuery = userQuery.Where(predicate);
			}

			return await userQuery.ToListAsync();
		}
	}
}
