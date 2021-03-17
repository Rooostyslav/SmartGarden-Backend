using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[Route("api/plants")]
	[ApiController]
	public class PlantsController : ControllerBase
	{
		private readonly IPlantService plantService;
		private readonly IActionService actionService;

		public PlantsController(IPlantService plantService, IActionService actionService)
		{
			this.plantService = plantService;
			this.actionService = actionService;
		}

		[HttpGet("{plantId}")]
		public async Task<IActionResult> GetPlantById(int plantId)
		{
			var plant = await plantService.FindPlantByIdAsync(plantId);

			if (plant != null)
			{
				return Ok(plant);
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CreatePlant([FromBody] CreatePlantDTO plant)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await plantService.CreateAsync(plant);

			return Ok();
		}

		[HttpDelete("{plantId}")]
		public async Task<IActionResult> DeletePlant(int plantId)
		{
			await plantService.DeleteAsync(plantId);

			return Ok();
		}

		[HttpGet("{plantId}/actions")]
		public async Task<IActionResult> GetActionsByPlants(int plantId)
		{
			var actions = await actionService.FindActionsByPlantAsync(plantId);

			if (actions.Count() > 0)
			{
				return Ok(actions);
			}

			return NoContent();
		}
	}
}
