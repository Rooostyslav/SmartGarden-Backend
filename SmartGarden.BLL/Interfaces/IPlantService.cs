using SmartGarden.BLL.DTO.Plants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IPlantService
	{
		Task<IEnumerable<PlantDTO>> FindPlantsByGardenAsync(int gardenId);

		Task<PlantDTO> FindPlantByIdAsync(int id);

		Task CreateAsync(CreatePlantDTO plantToCreate);

		Task DeleteAsync(int id);
	}
}
