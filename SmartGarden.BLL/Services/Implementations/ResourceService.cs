using AutoMapper;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGarden.DAL.UnitOfWork;
using SmartGarden.DAL.Repositories;

namespace SmartGarden.BLL.Services.Implementations
{
	public class ResourceService : IResourceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Resource> _resources;
		private readonly IMapper _mapper;

		public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_resources = unitOfWork.Resources;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ResourceDTO>> FindAllAsync()
		{
			var resources = await _resources.GetAllAsync();
			return _mapper.Map<IEnumerable<ResourceDTO>>(resources);
		}

		public async Task<ResourceDTO> FindByIdAsync(int id)
		{
			var resource = await _resources.GetByIdAsync(id);
			return _mapper.Map<ResourceDTO>(resource);
		}

		public async Task<ResourceDTO> CreateAsync(CreateResourceDTO resourceToCreate)
		{
			var resource = _mapper.Map<Resource>(resourceToCreate);
			var created = await _resources.InsertAsync(resource);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ResourceDTO>(created);
		}

		public async Task<ResourceDTO> UpdateAsync(UpdateResourceDTO resourceToUpdate)
		{
			var resource = await _resources.GetByIdAsync(resourceToUpdate.Id);
			resource = _mapper.Map(resourceToUpdate, resource);

			var updated = await _resources.UpdateAsync(resource);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ResourceDTO>(updated);
		}

		public async Task<ResourceDTO> DeleteAsync(int id)
		{
			var deleted = await _resources.DeleteAsync(id);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ResourceDTO>(deleted);
		}
	}
}
