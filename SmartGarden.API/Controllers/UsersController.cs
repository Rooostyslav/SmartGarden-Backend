using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
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

		[Authorize(Roles = "admin, user")]
		[HttpGet("my")]
		public async Task<IActionResult> GetMyUser()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var user = await userService.FindUserByIdAsync(userId);

			if (user != null)
			{
				return Ok(user);
			}

			return NotFound();
		}

		[Authorize(Roles = "admin, user")]
		[HttpGet("{userId}")]
		public async Task<IActionResult> GetUser(int userId)
		{
			var user = await userService.FindUserByIdAsync(userId);

			if (user != null)
			{
				return Ok(user);
			}

			return NotFound();
		}

		//[Authorize(Roles = "admin, user")]
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

		[Authorize(Roles = "admin, user")]
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

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO user)
		{
			if (user.Role == String.Empty || user.Role == null)
			{
				user.Role = "user";
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			bool existEmail = await userService.ExistEmailAsync(user.Email);
			if (existEmail)
			{
				return BadRequest("Email already exist!");
			}

			await userService.CreateAsync(user);

			return Ok();
		}
	}
}
