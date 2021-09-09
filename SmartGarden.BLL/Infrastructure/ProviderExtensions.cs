using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartGarden.BLL.Infrastructure.MappingProfiles;
using SmartGarden.BLL.Services;
using SmartGarden.BLL.Services.Implementations;
using SmartGarden.DAL.EF;
using SmartGarden.DAL.UnitOfWork;

namespace SmartGarden.BLL.Infrastructure
{
	public static class ProviderExtensions
	{
		public static void AddContextService(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<SmartGardenContext>(options =>
				options.UseSqlServer(connectionString));
		}

		public static void AddUnitOfWork(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IGardenService, GardenService>();
			services.AddScoped<IPlantService, PlantService>();
			services.AddScoped<IResourceService, ResourceService>();
			services.AddScoped<IActionService, ActionService>();
			services.AddScoped<IDeviceService, DeviceService>();
		}

		public static void AddBackupService(this IServiceCollection services, string connectionString,
			string connectionStringToMaster)
		{
			services.AddScoped<IBackupService>(b => 
				new BackupService(connectionString, connectionStringToMaster));
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mapperConfig =>
			{
				mapperConfig.AddProfile(new UserMappingProfile());
				mapperConfig.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}
	}
}
