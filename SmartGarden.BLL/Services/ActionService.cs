using AutoMapper;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class ActionService : IActionService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IActionRepository actionRepository;
		private readonly IMapper mapper;

		public ActionService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			actionRepository = unitOfWork.Actions;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreateActionDTO actionToCreate)
		{
			var action = mapper.Map<Action>(actionToCreate);
			await actionRepository.AddAsync(action);
			await unitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(int actionId)
		{
			await actionRepository.DeleteAsync(actionId);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewActionDTO> FindActionByIdAsync(int id)
		{
			var actions = await actionRepository
				.FindWithIncludesAsync(a => a.Id == id);
			var action = actions.FirstOrDefault();
			return mapper.Map<ViewActionDTO>(action);
		}

		public async Task<IEnumerable<ViewActionDTO>> FindActionsByPlantAsync(int plantId)
		{
			var actions = await actionRepository
				.FindWithIncludesAsync(a => a.PlantId == plantId);
			return mapper.Map<IEnumerable<ViewActionDTO>>(actions);
		}

		public async Task<IEnumerable<ViewActionDTO>> FindActionsByUserAsync(int userId)
		{
			var actions = await actionRepository
				.FindWithIncludesAsync(a => a.Plant.Garden.UserId == userId);
			return mapper.Map<IEnumerable<ViewActionDTO>>(actions);
		}

		public async Task<IEnumerable<ViewActionDTO>> FindUnfulfiledActionsByUserAsync(int userId)
		{
			var actions = await actionRepository
				.FindWithIncludesAsync(a => a.Status == false && a.Plant.Garden.UserId == userId);
			return mapper.Map<IEnumerable<ViewActionDTO>>(actions);
		}

		public async Task UpdateAsync(UpdateActionDTO actionToUpdate)
		{
			var action = mapper.Map<Action>(actionToUpdate);
			actionRepository.Update(action.Id, action);
			await unitOfWork.SaveAsync();
		}
	}
}
