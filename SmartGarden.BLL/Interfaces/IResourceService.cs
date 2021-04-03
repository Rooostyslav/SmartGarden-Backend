using SmartGarden.BLL.DTO.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IResourceService
	{
		Task<IEnumerable<ViewResourceDTO>> FindResourcesByGardenAsync(int gardenId);
	}
}
