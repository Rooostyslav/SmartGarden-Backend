using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[ApiController]
	[Route("api/actions")]
	[Authorize(Roles = "admin, user")]
	public class ActionsController : ControllerBase
	{
		private readonly IActionService _actionService;

		public ActionsController(IActionService actionService)
		{
			_actionService = actionService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetUsers()
		{
			var actions = await _actionService.FindAllAsync();

			if (actions.Count() > 0)
			{
				return Ok(actions);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetUserById(int id)
		{
			var action = await _actionService.FindByIdAsync(id);

			if (action != null)
			{
				return Ok(action);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyUser()
		{
			int myId = User.Id();
			var myUser = await _actionService.FindByIdAsync(myId);

			if (myUser != null)
			{
				return Ok(myUser);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateUser(
			[FromBody] CreateActionDTO actionToCreate)
		{
			var result = await _actionService.CreateAsync(actionToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateUser(
			[FromBody] UpdateActionDTO actionToUpdate)
		{
			var result = await _actionService.UpdateAsync(actionToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _actionService.DeleteAsync(id);
			return Ok();
		}
	}
}
