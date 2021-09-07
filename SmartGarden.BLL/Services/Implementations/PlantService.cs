using AutoMapper;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services.Implementations
{
	public class PlantService : IPlantService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Plant> _plants;
		private readonly IMapper _mapper;

		public PlantService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_plants = unitOfWork.Plants;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PlantDTO>> FindAllAsync()
		{
			var plants = await _plants.GetAllAsync();
			return _mapper.Map<IEnumerable<PlantDTO>>(plants);
		}

		public async Task<PlantDTO> FindByIdAsync(int id)
		{
			var plant = await _plants.GetByIdAsync(id);
			return _mapper.Map<PlantDTO>(plant);
		}

		public async Task<PlantDTO> CreateAsync(CreatePlantDTO plantToCreate)
		{
			var plant = _mapper.Map<Plant>(plantToCreate);
			var created = await _plants.InsertAsync(plant);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<PlantDTO>(created);
		}

		public async Task<PlantDTO> UpdateAsync(UpdatePlantDTO plantToUpdate)
		{
			var plant = await _plants.GetByIdAsync(plantToUpdate.Id);
			plant = _mapper.Map(plantToUpdate, plant);

			var updated = await _plants.UpdateAsync(plant);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<PlantDTO>(updated);
		}

		public async Task<PlantDTO> DeleteAsync(int id)
		{
			var deleted = await _plants.DeleteAsync(id);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<PlantDTO>(deleted);
		}
	}
}
