using SmartGarden.BLL.DTO.Plants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IPlantService
	{
		Task<IEnumerable<ViewPlantDTO>> FindPlantsByGardenAsync(int gardenId);

		Task<ViewPlantDTO> FindPlantByIdAsync(int id);

		Task CreateAsync(CreatePlantDTO plantToCreate);

		Task DeleteAsync(int id);
	}
}
