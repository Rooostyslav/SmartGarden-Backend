using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.Services;

namespace SmartGarden.API.Controllers
{
	[ApiController]
	[Route("api/gardens")]
	[Authorize(Roles = "admin, user")]
	public class GardensController : ControllerBase
	{
		private readonly IGardenService _gardenService;

		public GardensController(IGardenService gardenService)
		{
			_gardenService = gardenService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetGardens()
		{
			var gardens = await _gardenService.FindAllAsync();

			if (gardens.Count() > 0)
			{
				return Ok(gardens);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetGardenById(int id)
		{
			var garden = await _gardenService.FindByIdAsync(id);

			if (garden != null)
			{
				return Ok(garden);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateGarden(
			[FromBody] CreateGardenDTO gardenToCreate)
		{
			var result = await _gardenService.CreateAsync(gardenToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateGarden(
			[FromBody] UpdateGardenDTO gardenToUpdate)
		{
			var result = await _gardenService.UpdateAsync(gardenToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteGarden(int id)
		{
			await _gardenService.DeleteAsync(id);
			return Ok();
		}
	}
}
