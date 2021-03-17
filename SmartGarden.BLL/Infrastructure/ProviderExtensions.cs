using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartGarden.BLL.Interfaces;
using SmartGarden.BLL.Services;
using SmartGarden.DAL.EF;
using SmartGarden.DAL.Interfaces;
using SmartGarden.DAL.Repositories;

namespace SmartGarden.BLL.Infrastructure
{
	public static class ProviderExtensions
	{
		public static void AddContextService(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<SmartGardenContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddTransient<IUnitOfWork>(u => new UnitOfWork(connectionString));
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mapperConfig =>
			{
				mapperConfig.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IGardenService, GardenService>();
			services.AddSingleton<IPlantService, PlantService>();
			services.AddSingleton<IResourceService, ResourceService>();
			services.AddSingleton<IActionService, ActionService>();
		}

	}
}
