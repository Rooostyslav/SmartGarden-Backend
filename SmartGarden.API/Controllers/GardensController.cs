using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.Interfaces;
using System;
using SmartGarden.API.Claims;

namespace SmartGarden.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/gardens")]
	[ApiController]
	public class GardensController : ControllerBase
	{
		private readonly IGardenService gardenService;
		private readonly IPlantService plantService;
		private readonly IResourceService resourceService;

		public GardensController(IGardenService gardenService, IPlantService plantService,
			IResourceService resourceService)
		{
			this.gardenService = gardenService;
			this.plantService = plantService;
			this.resourceService = resourceService;
		}

		[HttpGet("my")]
		public async Task<IActionResult> GetMyGardens()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var gardens = await gardenService.FindGardenByUserAsync(userId);

			if (gardens.Count() > 0)
			{
				return Ok(gardens);
			}

			return NoContent();
		}

		[HttpGet("{gardenId}")]
		public async Task<IActionResult> GetGardenById(int gardenId)
		{
			var garden = await gardenService.FindGardenByIdAsync(gardenId);

			if (garden != null)
			{
				return Ok(garden);
			}

			return NotFound();
		}

		[HttpGet("{gardenId}/plants")]
		public async Task<IActionResult> GetPlantsByGarden(int gardenId)
		{
			var plants = await plantService.FindPlantsByGardenAsync(gardenId);

			if (plants.Count() > 0)
			{
				return Ok(plants);
			}

			return NoContent();
		}

		[HttpGet("{gardenId}/resources")]
		public async Task<IActionResult> GetResourcesByGarden(int gardenId)
		{
			var resources = await resourceService.FindResourcesByGardenAsync(gardenId);

			if (resources.Count() > 0)
			{
				return Ok(resources);
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateGarden([FromBody] CreateGardenDTO garden)
		{
			if (garden.UserId == 0)
			{
				string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;
				if (!Int32.TryParse(userIdString, out int userId))
				{
					return NotFound();
				}

				garden.UserId = userId;
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await gardenService.CreateAsync(garden);

			return Ok();
		}
	}
}
