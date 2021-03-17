using AutoMapper;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class ResourceService : IResourceService
	{
		private readonly IResourсeRepository resourсeRepository;
		private readonly IMapper mapper;

		public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			resourсeRepository = unitOfWork.Resourсes;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ResourceDTO>> FindResourcesByGardenAsync(int gardenId)
		{
			var resources = await resourсeRepository.FindWithIncludesAsync(r => r.GardenId == gardenId);
			return mapper.Map<IEnumerable<ResourceDTO>>(resources);
		}
	}
}
