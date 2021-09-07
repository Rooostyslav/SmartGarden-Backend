using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.BLL.DTO.Backups;
using SmartGarden.BLL.Services;

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
		public async Task<IActionResult> GetAllBackupsFilesNames()
		{
			var backupsFileNames = await Task.Run(() => backupService.FindAllBackupsFileNames());

			if (backupsFileNames.Count() > 0)
			{
				return Ok(backupsFileNames);
			}

			return NoContent();
		}

		[Route("create")]
		[HttpGet]
		public async Task<IActionResult> CreateBackup()
		{
			string physicalPath = await backupService.CreateBackupAsync();

			string fileName = Path.GetFileName(physicalPath);
			string contentType = "application/bak";

			return PhysicalFile(physicalPath, contentType, fileName);
		}

		[HttpPost("apply")]
		public async Task<IActionResult> ApplyBackup([FromBody] Backup backup)
		{
			await backupService.ApplyBackup(backup.FileName);

			return Ok();
		}
	}
}
