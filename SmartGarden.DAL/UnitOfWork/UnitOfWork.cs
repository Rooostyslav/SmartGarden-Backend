using SmartGarden.DAL.EF;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using System.Threading.Tasks;

namespace SmartGarden.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SmartGardenContext _context;
		private IRepository<User> _users;
		private IRepository<Garden> _gardens;
		private IRepository<Plant> _plants;
		private IRepository<Action> _actions;
		private IRepository<Resource> _resourсes;
		private IRepository<Device> _devices;

		public UnitOfWork(SmartGardenContext context)
		{
			_context = context;
		}

		public IRepository<User> Users
		{
			get
			{
				if (_users == null)
				{
					_users = new Repository<User>(_context);
				}

				return _users;
			}
		}

		public IRepository<Garden> Gardens
		{
			get
			{
				if (_gardens == null)
				{
					_gardens = new Repository<Garden>(_context);
				}

				return _gardens;
			}
		}

		public IRepository<Plant> Plants
		{
			get
			{
				if (_plants == null)
				{
					_plants = new Repository<Plant>(_context);
				}

				return _plants;
			}
		}

		public IRepository<Action> Actions
		{
			get
			{
				if (_actions == null)
				{
					_actions = new Repository<Action>(_context);
				}

				return _actions;
			}
		}

		public IRepository<Resource> Resources
		{
			get
			{
				if (_resourсes == null)
				{
					_resourсes = new Repository<Resource>(_context);
				}

				return _resourсes;
			}
		}

		public IRepository<Device> Devices
		{
			get
			{
				if (_devices == null)
				{
					_devices = new Repository<Device>(_context);
				}

				return _devices;
			}
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
