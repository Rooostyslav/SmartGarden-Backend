using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.Interfaces;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[Route("api/actions")]
	[ApiController]
	public class ActionsController : ControllerBase
	{
		private readonly IActionService actionService;

		public ActionsController(IActionService actionService)
		{
			this.actionService = actionService;
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
		public async Task<IActionResult> UpdateAction([FromBody] UpdateActionDTO action)
		{
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
