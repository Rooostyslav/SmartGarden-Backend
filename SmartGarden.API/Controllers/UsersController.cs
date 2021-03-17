using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.API.Controllers
{
	[Route("api/users/{userId}/gardens")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IGardenService gardenService;

		public UsersController(IGardenService gardenService)
		{
			this.gardenService = gardenService;
		}

		[HttpGet]
		public async Task<IActionResult> GetGardensByUser(int userId)
		{
			var gardens = await gardenService.FindGardenByUserAsync(userId);

			if (gardens.Count() > 0)
			{
				return Ok(gardens);
			}

			return NoContent();
		}
	}
}
