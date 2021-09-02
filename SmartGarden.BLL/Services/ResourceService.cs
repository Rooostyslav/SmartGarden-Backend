using AutoMapper;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGarden.DAL.UnitOfWork;
using SmartGarden.DAL.Repositories;

namespace SmartGarden.BLL.Services
{
	public class ResourceService : IResourceService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<Resource> _resources;
		private readonly IMapper mapper;

		public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			_resources = unitOfWork.Resources;
			this.mapper = mapper;
		}

		public async Task CreateResourceAsync(CreateResourceDTO resourceToCreate)
		{
			var resource = mapper.Map<Resource>(resourceToCreate);
			await _resources.InsertAsync(resource);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewResourceDTO> FindResourceByIdAsync(int id)
		{
			var resource = await _resources.GetByIdAsync(id);
			return mapper.Map<ViewResourceDTO>(resource);
		}

		public async Task<IEnumerable<ViewResourceDTO>> FindResourcesByGardenAsync(int gardenId)
		{
			var resources = await _resources.GetAllAsync(r => r.GardenId == gardenId);
			return mapper.Map<IEnumerable<ViewResourceDTO>>(resources);
		}

		public async Task<IEnumerable<ViewResourceDTO>> FindResourcesByUserAsync(int userId)
		{
			var resources = await _resources.GetAllAsync(r => r.Garden.UserId == userId);
			return mapper.Map<IEnumerable<ViewResourceDTO>>(resources);
		}
	}
}
