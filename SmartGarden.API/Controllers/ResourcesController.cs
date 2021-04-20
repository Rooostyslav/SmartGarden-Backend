using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/resources")]
	[ApiController]
	public class ResourcesController : ControllerBase
	{
		private readonly IResourceService resourceService;
		private readonly IGardenService gardenService;
		public ResourcesController(IResourceService resourceService,	
			IGardenService gardenService)
		{
			this.resourceService = resourceService;
			this.gardenService = gardenService;
		}


		[HttpGet("my")]
		public async Task<IActionResult> GetMyResources()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var resources = await resourceService.FindResourcesByUserAsync(userId);

			if (resources.Count() > 0)
			{
				return Ok(resources);
			}

			return NoContent();
		}

		[HttpGet("{resourceId}")]
		public async Task<IActionResult> GetResourceById(int resourceId)
		{
			var resource = await resourceService.FindResourceByIdAsync(resourceId);

			if (resource != null)
			{
				return Ok(resource);
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateResource([FromBody] CreateResourceDTO resource)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (resource.GardenId == 0)
			{
				string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

				if (!Int32.TryParse(userIdString, out int userId))
				{
					return NotFound();
				}

				var gardens = await gardenService.FindGardenByUserAsync(userId);
				resource.GardenId = gardens.First().Id;
			}

			await resourceService.CreateResourceAsync(resource);

			return Ok();
		}
	}
}
