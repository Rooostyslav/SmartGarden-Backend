using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using System.Threading.Tasks;

namespace SmartGarden.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<User> Users { get; }

		IRepository<Garden> Gardens { get; }

		IRepository<Plant> Plants { get; }

		IRepository<Action> Actions { get; }

		IRepository<Resource> Resources { get; }

		Task SaveAsync();
	}
}
