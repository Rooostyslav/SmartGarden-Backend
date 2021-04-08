using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.API.Claims;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/resources")]
	[ApiController]
	public class ResourcesController : ControllerBase
	{
		private readonly IResourceService resourcesService;
		public ResourcesController(IResourceService resourcesService)
		{
			this.resourcesService = resourcesService;
		}


		[HttpGet("my")]
		public async Task<IActionResult> GetMyActions()
		{
			string userIdString = User.FindFirst(x => x.Type == ClaimTypes.Id).Value;

			if (!Int32.TryParse(userIdString, out int userId))
			{
				return NotFound();
			}

			var resources = await resourcesService.FindResourcesByUserAsync(userId);

			if (resources.Count() > 0)
			{
				return Ok(resources);
			}

			return NoContent();
		}
	}
}
