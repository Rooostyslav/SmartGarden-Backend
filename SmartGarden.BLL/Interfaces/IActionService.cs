using SmartGarden.BLL.DTO.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IActionService
	{
		Task<IEnumerable<ViewActionDTO>> FindActionsByPlantAsync(int plantId);

		Task<ActionDTO> FindActionByIdAsync(int id);

		Task<IEnumerable<ViewActionDTO>> FindActionsByUserAsync(int userId);

		Task<IEnumerable<ViewActionDTO>> FindUnfulfiledActionsByUserAsync(int userId);

		Task CreateAsync(CreateActionDTO actionToCreate);

		Task UpdateAsync(UpdateActionDTO actionToUpdate);

		Task DeleteAsync(int actionId);
	}
}
