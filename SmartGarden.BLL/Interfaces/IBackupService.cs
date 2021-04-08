using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IBackupService
	{
		string BackupsFolder { get; }

		Task<string> CreateBackupAsync();
	}
}
