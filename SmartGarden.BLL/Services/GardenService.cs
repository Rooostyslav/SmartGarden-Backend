using AutoMapper;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class GardenService : IGardenService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<Garden> _gardens;
		private readonly IMapper mapper;

		public GardenService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			_gardens = unitOfWork.Gardens;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreateGardenDTO gardenToCreate)
		{
			var garden = mapper.Map<Garden>(gardenToCreate);
			await _gardens.InsertAsync(garden);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewGardenDTO> FindGardenByIdAsync(int id)
		{
			var garden = await _gardens.GetByIdAsync(id);
			return mapper.Map<ViewGardenDTO>(garden);
		}

		public async Task<IEnumerable<ViewGardenDTO>> FindGardenByUserAsync(int userId)
		{
			var gardens = await _gardens.GetAllAsync(g => g.UserId == userId);
			return mapper.Map<IEnumerable<ViewGardenDTO>>(gardens);
		}
	}
}
