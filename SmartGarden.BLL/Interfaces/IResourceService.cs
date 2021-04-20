using SmartGarden.BLL.DTO.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IResourceService
	{
		Task<ViewResourceDTO> FindResourceByIdAsync(int id);

		Task<IEnumerable<ViewResourceDTO>> FindResourcesByUserAsync(int userId);

		Task<IEnumerable<ViewResourceDTO>> FindResourcesByGardenAsync(int gardenId);

		Task CreateResourceAsync(CreateResourceDTO resourceToCreate);
	}
}
