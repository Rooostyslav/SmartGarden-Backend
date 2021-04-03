using SmartGarden.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> FindWithIncludesAsync(Expression<Func<User, bool>> predicate);

		Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate);

		Task<User> FindByIdAsync(object id);

		Task AddAsync(User user);

		void Update(int id, User userToUpddate);

		Task DeleteAsync(object id);
	}
}
