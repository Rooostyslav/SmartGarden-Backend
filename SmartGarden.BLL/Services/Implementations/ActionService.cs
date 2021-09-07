using AutoMapper;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services.Implementations
{
	public class ActionService : IActionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Action> _actions;
		private readonly IMapper _mapper;

		public ActionService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_actions = unitOfWork.Actions;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ActionDTO>> FindAllAsync()
		{
			var actions = await _actions.GetAllAsync();
			return _mapper.Map<IEnumerable<ActionDTO>>(actions);
		}

		public async Task<ActionDTO> FindByIdAsync(int id)
		{
			var action = await _actions.GetByIdAsync(id);
			return _mapper.Map<ActionDTO>(action);
		}

		public async Task<ActionDTO> CreateAsync(CreateActionDTO actionToCreate)
		{
			var action = _mapper.Map<Action>(actionToCreate);
			var created = await _actions.InsertAsync(action);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ActionDTO>(created);
		}

		public async Task<ActionDTO> UpdateAsync(UpdateActionDTO actionToUpdate)
		{
			var action = await _actions.GetByIdAsync(actionToUpdate.Id);
			action = _mapper.Map(actionToUpdate, action);

			var updated = await _actions.UpdateAsync(action);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ActionDTO>(updated);
		}

		public async Task<ActionDTO> DeleteAsync(int id)
		{
			var deleted = await _actions.DeleteAsync(id);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ActionDTO>(deleted);
		}
	}
}
