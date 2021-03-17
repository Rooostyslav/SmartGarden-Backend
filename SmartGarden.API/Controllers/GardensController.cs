using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.API.Controllers
{
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

		[HttpPost]
		public async Task<IActionResult> CreateGarden([FromBody] CreateGardenDTO garden)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await gardenService.CreateAsync(garden);

			return Ok();
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
	}
}
