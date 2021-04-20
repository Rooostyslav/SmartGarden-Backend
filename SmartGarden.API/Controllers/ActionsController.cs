using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/actions")]
	[ApiController]
	public class ActionsController : ControllerBase
	{
		private readonly IActionService actionService;
		private readonly IPlantService plantService;

		public ActionsController(IActionService actionService, IPlantService plantService)
		{
			this.actionService = actionService;
			this.plantService = plantService;
		}

		[HttpGet("my")]
		public async Task<IActionResult> GetMyActions()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var actions = await actionService.FindActionsByUserAsync(userId);

			if (actions.Count() > 0)
			{
				return Ok(actions);
			}

			return NoContent();
		}

		[HttpGet("my/unfulfiled")]
		public async Task<IActionResult> GetMyUnfulfiledActions()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var unfulfiledActions = await actionService.FindUnfulfiledActionsByUserAsync(userId);

			if (unfulfiledActions.Count() > 0)
			{
				return Ok(unfulfiledActions);
			}

			return NoContent();
		}

		[HttpGet("{actionId}")]
		public async Task<IActionResult> GetActionById(int actionId)
		{
			var action = await actionService.FindActionByIdAsync(actionId);

			if (action != null)
			{
				return Ok(action);
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAction([FromBody] CreateActionDTO action)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (action.PlantId == 0)
			{
				string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

				if (!Int32.TryParse(userIdString, out int userId))
				{
					return NotFound();
				}

				var plants = await plantService.FindPlantsByUserAsync(userId);
				int plantId = plants.First().Id;

				action.PlantId = plantId;
			}

			await actionService.CreateAsync(action);

			return Ok();
		}

		[HttpPut("{actionId}")]
		public async Task<IActionResult> UpdateAction(int actionId, [FromBody] UpdateActionDTO action)
		{
			action.Id = actionId;

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await actionService.UpdateAsync(action);

			return Ok();
		}

		[HttpDelete("{actionId}")]
		public async Task<IActionResult> DeleteAction(int actionId)
		{
			await actionService.DeleteAsync(actionId);

			return Ok();
		}
	}
}
