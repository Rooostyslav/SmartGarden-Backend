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

			services.AddScoped<IUnitOfWork, UnitOfWork>();
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
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IGardenService, GardenService>();
			services.AddScoped<IPlantService, PlantService>();
			services.AddScoped<IResourceService, ResourceService>();
			services.AddScoped<IActionService, ActionService>();
		}

		public static void AddBackupService(this IServiceCollection services, string connectionString,
			string connectionStringToMaster)
		{
			services.AddScoped<IBackupService>(b => 
				new BackupService(connectionString, connectionStringToMaster));
		}
	}
}
