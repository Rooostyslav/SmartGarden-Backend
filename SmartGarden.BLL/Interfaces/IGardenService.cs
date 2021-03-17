using SmartGarden.BLL.DTO.Gardens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IGardenService
	{
		Task<IEnumerable<GardenDTO>> FindGardenByUserAsync(int userId);

		Task CreateAsync(CreateGardenDTO gardenToCreate);
	}
}
