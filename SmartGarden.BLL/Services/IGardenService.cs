using SmartGarden.BLL.DTO.Gardens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public interface IGardenService
	{
		Task<IEnumerable<GardenDTO>> FindAllAsync();

		Task<GardenDTO> FindByIdAsync(int id);

		Task<GardenDTO> CreateAsync(CreateGardenDTO gardenToCreate);

		Task<GardenDTO> UpdateAsync(UpdateGardenDTO gardenToUpdate);

		Task<GardenDTO> DeleteAsync(int id);
	}
}
