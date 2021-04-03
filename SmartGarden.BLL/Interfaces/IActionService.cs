using SmartGarden.BLL.DTO.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IActionService
	{
		Task<IEnumerable<ViewActionDTO>> FindActionsByPlantAsync(int plantId);

		Task<ActionDTO> FindActionByIdAsync(int id);

		Task CreateAsync(CreateActionDTO actionToCreate);

		Task UpdateAsync(UpdateActionDTO actionToUpdate);

		Task DeleteAsync(int actionId);
	}
}
