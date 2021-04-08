using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.API.Controllers
{
	//[Authorize(Roles = "admin")]
	[Route("api/backups")]
	[ApiController]
	public class BackupsController : ControllerBase
	{
		private readonly IBackupService backupService;

		public BackupsController(IBackupService backupService)
		{
			this.backupService = backupService;
		}

		[HttpGet]
		public async Task<IActionResult> CreateBackup()
		{
			string physicalPath = await backupService.CreateBackupAsync();

			string fileName = Path.GetFileName(physicalPath);
			string contentType = "application/bak";

			return PhysicalFile(physicalPath, contentType, fileName);
		}
	}
}
