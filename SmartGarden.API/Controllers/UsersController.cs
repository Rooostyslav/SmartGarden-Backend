using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IGardenService gardenService;

		public UsersController(IUserService userService, IGardenService gardenService)
		{
			this.gardenService = gardenService;
			this.userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = await userService.FindAllUsersAsync();

			if (users.Count() > 0)
			{
				return Ok(users);
			}

			return NoContent();
		}

		[HttpGet("{userId}/gardens")]
		public async Task<IActionResult> GetGardensByUser(int userId)
		{
			var gardens = await gardenService.FindGardenByUserAsync(userId);

			if (gardens.Count() > 0)
			{
				return Ok(gardens);
			}

			return NoContent();
		}

		public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await userService.CreateAsync(user);

			return Ok();
		}
	}
}
