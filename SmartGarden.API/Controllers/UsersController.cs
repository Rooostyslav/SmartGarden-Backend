using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Services;

namespace SmartGarden.API.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		//[Authorize]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _userService.FindAllAsync();
			
			if (users.Count() > 0)
			{
				return Ok(users);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		//[Authorize]
		public async Task<IActionResult> GetUserById(int id)
		{
			var user = await _userService.FindByIdAsync(id);

			if (user != null)
			{
				return Ok(user);
			}

			return NotFound();
		}

		[HttpGet("my")]
		//[Authorize]
		public async Task<IActionResult> GetMyUser()
		{
			int myId = 2; //User.Id();
			var myUser = await _userService.FindByIdAsync(myId);

			if (myUser != null)
			{
				return Ok(myUser);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateUser(
			[FromBody] CreateUserDTO userToCreate)
		{
			var result = await _userService.CreateAsync(userToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		//[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateUser(
			[FromBody] UpdateUserDTO userToUpdate)
		{
			var result = await _userService.UpdateAsync(userToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		//[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _userService.DeleteAsync(id);
			return Ok();
		}
	}
}
