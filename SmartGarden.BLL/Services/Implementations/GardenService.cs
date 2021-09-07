using AutoMapper;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services.Implementations
{
	public class GardenService : IGardenService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Garden> _gardens;
		private readonly IMapper _mapper;

		public GardenService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_gardens = unitOfWork.Gardens;
			_mapper = mapper;
		}

		public async Task<IEnumerable<GardenDTO>> FindAllAsync()
		{
			var gardens = await _gardens.GetAllAsync();
			return _mapper.Map<IEnumerable<GardenDTO>>(gardens);
		}

		public async Task<GardenDTO> FindByIdAsync(int id)
		{
			var garden = await _gardens.GetByIdAsync(id);
			return _mapper.Map<GardenDTO>(garden);
		}

		public async Task<GardenDTO> CreateAsync(CreateGardenDTO gardenToCreate)
		{
			var garden = _mapper.Map<Garden>(gardenToCreate);
			var created = await _gardens.InsertAsync(garden);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<GardenDTO>(created);
		}

		public async Task<GardenDTO> UpdateAsync(UpdateGardenDTO gardenToUpdate)
		{
			var garden = await _gardens.GetByIdAsync(gardenToUpdate.Id);
			garden = _mapper.Map(gardenToUpdate, garden);

			var updated = await _gardens.UpdateAsync(garden);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<GardenDTO>(updated);
		}

		public async Task<GardenDTO> DeleteAsync(int id)
		{
			var deleted = await _gardens.DeleteAsync(id);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<GardenDTO>(deleted);
		}
	}
}
