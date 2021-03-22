using AutoMapper;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class GardenService : IGardenService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IGardenRepository gardenRepository;
		private readonly IMapper mapper;

		public GardenService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			gardenRepository = unitOfWork.Gardens;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreateGardenDTO gardenToCreate)
		{
			var garden = mapper.Map<Garden>(gardenToCreate);
			await gardenRepository.AddAsync(garden);
			await unitOfWork.SaveAsync();
		}

		public async Task<IEnumerable<ViewGardenDTO>> FindGardenByUserAsync(int userId)
		{
			var gardens = await gardenRepository.FindWithIncludesAsync(g => g.UserId == userId);
			return mapper.Map<IEnumerable<ViewGardenDTO>>(gardens);
		}
	}
}
