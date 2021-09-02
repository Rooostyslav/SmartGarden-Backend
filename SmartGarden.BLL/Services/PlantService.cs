using AutoMapper;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class PlantService : IPlantService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<Plant> _plants;
		private readonly IMapper mapper;

		public PlantService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			_plants = unitOfWork.Plants;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreatePlantDTO plantToCreate)
		{
			var plant = mapper.Map<Plant>(plantToCreate);
			await _plants.InsertAsync(plant);
			await unitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _plants.DeleteAsync(id);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewPlantDTO> FindPlantByIdAsync(int id)
		{
			var plant = await _plants.GetByIdAsync(id);
			return mapper.Map<ViewPlantDTO>(plant);
		}

		public async Task<IEnumerable<ViewPlantDTO>> FindPlantsByGardenAsync(int gardenId)
		{
			var plants = await _plants.GetAllAsync(p => p.GardenId == gardenId);
			return mapper.Map<IEnumerable<ViewPlantDTO>>(plants);
		}

		public async Task<IEnumerable<ViewPlantDTO>> FindPlantsByUserAsync(int userId)
		{
			var plants = await _plants.GetAllAsync(p => p.Garden.UserId == userId);
			return mapper.Map<IEnumerable<ViewPlantDTO>>(plants);
		}
	}
}
