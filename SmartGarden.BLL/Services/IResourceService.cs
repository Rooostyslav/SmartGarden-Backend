using SmartGarden.BLL.DTO.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public interface IResourceService
	{
		Task<IEnumerable<ResourceDTO>> FindAllAsync();

		Task<ResourceDTO> FindByIdAsync(int id);

		Task<ResourceDTO> CreateAsync(CreateResourceDTO resourceToCreate);

		Task<ResourceDTO> UpdateAsync(UpdateResourceDTO resourceToUpdate);

		Task<ResourceDTO> DeleteAsync(int id);
	}
}
