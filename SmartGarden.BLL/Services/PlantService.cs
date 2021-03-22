using AutoMapper;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class PlantService : IPlantService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IPlantRepository plantRepository;
		private readonly IMapper mapper;

		public PlantService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			plantRepository = unitOfWork.Plants;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreatePlantDTO plantToCreate)
		{
			var plant = mapper.Map<Plant>(plantToCreate);
			await plantRepository.AddAsync(plant);
			await unitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await plantRepository.DeleteAsync(id);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewPlantDTO> FindPlantByIdAsync(int id)
		{
			var plants = await plantRepository.FindWithIncludesAsync(p => p.Id == id);
			var plant = plants.FirstOrDefault();
			return mapper.Map<ViewPlantDTO>(plant);
		}

		public async Task<IEnumerable<ViewPlantDTO>> FindPlantsByGardenAsync(int gardenId)
		{
			var plants = await plantRepository.FindWithIncludesAsync(p => p.GardenId == gardenId);
			return mapper.Map<IEnumerable<ViewPlantDTO>>(plants);
		}
	}
}
