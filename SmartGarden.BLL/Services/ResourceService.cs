using AutoMapper;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SmartGarden.BLL.Services
{
	public class ResourceService : IResourceService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IResourсeRepository resourсeRepository;
		private readonly IMapper mapper;

		public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			resourсeRepository = unitOfWork.Resourсes;
			this.mapper = mapper;
		}

		public async Task CreateResourceAsync(CreateResourceDTO resourceToCreate)
		{
			var resource = mapper.Map<Resource>(resourceToCreate);
			await resourсeRepository.AddAsync(resource);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewResourceDTO> FindResourceByIdAsync(int id)
		{
			var resources = await resourсeRepository
				.FindWithIncludesAsync(a => a.Id == id);
			var resource = resources.FirstOrDefault();
			return mapper.Map<ViewResourceDTO>(resource);
		}

		public async Task<IEnumerable<ViewResourceDTO>> FindResourcesByGardenAsync(int gardenId)
		{
			var resources = await resourсeRepository
				.FindWithIncludesAsync(r => r.GardenId == gardenId);
			return mapper.Map<IEnumerable<ViewResourceDTO>>(resources);
		}

		public async Task<IEnumerable<ViewResourceDTO>> FindResourcesByUserAsync(int userId)
		{
			var resources = await resourсeRepository
				.FindWithIncludesAsync(r => r.Garden.UserId == userId);
			return mapper.Map<IEnumerable<ViewResourceDTO>>(resources);
		}
	}
}
