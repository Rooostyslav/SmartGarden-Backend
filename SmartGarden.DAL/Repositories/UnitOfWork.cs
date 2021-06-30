using SmartGarden.DAL.EF;
using SmartGarden.DAL.Interfaces;
using System.Threading.Tasks;

namespace SmartGarden.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SmartGardenContext smartGardenContext;
		private IUserRepository userRepository;
		private IGardenRepository gardenRepository;
		private IPlantRepository plantRepository;
		private IActionRepository actionRepository;
		private IResourсeRepository resourсeRepository;

		public UnitOfWork(SmartGardenContext context)
		{
			smartGardenContext = context;
		}

		public IUserRepository Users
		{
			get
			{
				if (userRepository == null)
				{
					userRepository = new UserRepository(smartGardenContext);
				}

				return userRepository;
			}
		}

		public IGardenRepository Gardens
		{
			get
			{
				if (gardenRepository == null)
				{
					gardenRepository = new GardenRepository(smartGardenContext);
				}

				return gardenRepository;
			}
		}

		public IPlantRepository Plants
		{
			get
			{
				if (plantRepository == null)
				{
					plantRepository = new PlantRepository(smartGardenContext);
				}

				return plantRepository;
			}
		}

		public IActionRepository Actions
		{
			get
			{
				if (actionRepository == null)
				{
					actionRepository = new ActionRepository(smartGardenContext);
				}

				return actionRepository;
			}
		}

		public IResourсeRepository Resourсes
		{
			get
			{
				if (resourсeRepository == null)
				{
					resourсeRepository = new ResourceRepository(smartGardenContext);
				}

				return resourсeRepository;
			}
		}

		public async Task SaveAsync()
		{
			await smartGardenContext.SaveChangesAsync();
		}
	}
}
