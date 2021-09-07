using SmartGarden.BLL.DTO.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public interface IActionService
	{
		Task<IEnumerable<ActionDTO>> FindAllAsync();

		Task<ActionDTO> FindByIdAsync(int id);

		Task<ActionDTO> CreateAsync(CreateActionDTO actionToCreate);

		Task<ActionDTO> UpdateAsync(UpdateActionDTO actionToUpdate);

		Task<ActionDTO> DeleteAsync(int id);
	}
}
