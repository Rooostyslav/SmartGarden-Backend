using System.Threading.Tasks;

namespace SmartGarden.DAL.Interfaces
{
	public interface IUnitOfWork
	{
		IUserRepository Users { get; }

		IGardenRepository Gardens { get; }

		IPlantRepository Plants { get; }

		IActionRepository Actions { get; }

		IResourсeRepository Resourсes { get; }

		Task SaveAsync();
	}
}
