using AutoMapper;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Entity.Common;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class ActionService : IActionService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<Action> _actions;
		private readonly IMapper mapper;

		public ActionService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			_actions = unitOfWork.Actions;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreateActionDTO actionToCreate)
		{
			var action = mapper.Map<Action>(actionToCreate);
			await _actions.InsertAsync(action);
			await unitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(int actionId)
		{
			await _actions.DeleteAsync(actionId);
			await unitOfWork.SaveAsync();
		}

		public async Task<ViewActionDTO> FindActionByIdAsync(int id)
		{
			var action = await _actions.GetByIdAsync(id);
			return mapper.Map<ViewActionDTO>(action);
		}

		public async Task<IEnumerable<ViewActionDTO>> FindActionsByPlantAsync(int plantId)
		{
			var actions = await _actions.GetAllAsync(a => a.PlantId == plantId);
			return mapper.Map<IEnumerable<ViewActionDTO>>(actions);
		}

		public async Task<IEnumerable<ViewActionDTO>> FindActionsByUserAsync(int userId)
		{
			var actions = await _actions
				.GetAllAsync(a => a.Plant.Garden.UserId == userId);
			return mapper.Map<IEnumerable<ViewActionDTO>>(actions);
		}

		public async Task<IEnumerable<ViewActionDTO>> FindUnfulfiledActionsByUserAsync(int userId)
		{
			var actions = await _actions.GetAllAsync(a => 
				a.Status == Status.InProgress && 
				a.Plant.Garden.UserId == userId);

			return mapper.Map<IEnumerable<ViewActionDTO>>(actions);
		}

		public async Task UpdateAsync(UpdateActionDTO actionToUpdate)
		{
			var action = mapper.Map<Action>(actionToUpdate);
			await _actions.UpdateAsync(action);
			await unitOfWork.SaveAsync();
		}
	}
}
