using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[ApiController]
	[Route("api/plants")]
	[Authorize(Roles = "admin, plant")]
	public class PlantsController : ControllerBase
	{
		private readonly IPlantService _plantService;

		public PlantsController(IPlantService plantService)
		{
			_plantService = plantService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetPlants()
		{
			var plants = await _plantService.FindAllAsync();

			if (plants.Count() > 0)
			{
				return Ok(plants);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetPlantById(int id)
		{
			var plant = await _plantService.FindByIdAsync(id);

			if (plant != null)
			{
				return Ok(plant);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreatePlant(
			[FromBody] CreatePlantDTO plantToCreate)
		{
			var result = await _plantService.CreateAsync(plantToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdatePlant(
			[FromBody] UpdatePlantDTO plantToUpdate)
		{
			var result = await _plantService.UpdateAsync(plantToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeletePlant(int id)
		{
			await _plantService.DeleteAsync(id);
			return Ok();
		}
	}
}
