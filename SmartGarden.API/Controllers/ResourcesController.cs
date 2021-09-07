using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.Services;

namespace SmartGarden.API.Controllers
{
	[ApiController]
	[Route("api/resources")]
	[Authorize(Roles = "admin, user")]
	public class ResourcesController : ControllerBase
	{
		private readonly IResourceService _resourceService;
		public ResourcesController(IResourceService resourceService)
		{
			_resourceService = resourceService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetResources()
		{
			var resources = await _resourceService.FindAllAsync();

			if (resources.Count() > 0)
			{
				return Ok(resources);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetResourceById(int id)
		{
			var resource = await _resourceService.FindByIdAsync(id);

			if (resource != null)
			{
				return Ok(resource);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateResource(
			[FromBody] CreateResourceDTO resourceToCreate)
		{
			var result = await _resourceService.CreateAsync(resourceToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateResource(
			[FromBody] UpdateResourceDTO resourceToUpdate)
		{
			var result = await _resourceService.UpdateAsync(resourceToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteResource(int id)
		{
			await _resourceService.DeleteAsync(id);
			return Ok();
		}
	}
}
