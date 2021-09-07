using SmartGarden.BLL.DTO.Plants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public interface IPlantService
	{
		Task<IEnumerable<PlantDTO>> FindAllAsync();

		Task<PlantDTO> FindByIdAsync(int id);

		Task<PlantDTO> CreateAsync(CreatePlantDTO plantToCreate);

		Task<PlantDTO> UpdateAsync(UpdatePlantDTO plantToUpdate);

		Task<PlantDTO> DeleteAsync(int id);
	}
}
