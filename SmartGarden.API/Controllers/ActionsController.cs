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

		public ActionsController(IActionService actionService)
		{
			this.actionService = actionService;
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
		public async Task<IActionResult> GetPlantsById(int actionId)
		{
			var plants = await actionService.FindActionByIdAsync(actionId);

			if (plants != null)
			{
				return Ok(plants);
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
