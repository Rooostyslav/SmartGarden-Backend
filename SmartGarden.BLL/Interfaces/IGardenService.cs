using SmartGarden.BLL.DTO.Gardens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IGardenService
	{
		Task<IEnumerable<ViewGardenDTO>> FindGardenByUserAsync(int userId);

		Task<ViewGardenDTO> FindGardenByIdAsync(int id);

		Task CreateAsync(CreateGardenDTO gardenToCreate);
	}
}
