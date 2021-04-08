using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[Authorize(Roles = "admin, user")]
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

		[HttpGet("my")]
		public async Task<IActionResult> GetPlantById()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var plants = await plantService.FindPlantsByUserAsync(userId);

			if (plants.Count() > 0)
			{
				return Ok(plants);
			}

			return NotFound();
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

		[HttpGet("{plantId}/condition")]
		public async Task<IActionResult> GetConditionPlant(int plantId)
		{
			double plantCondition = await plantService.PlantCondition(plantId);

			return Ok(new 
			{
				condition = plantCondition
			});
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
