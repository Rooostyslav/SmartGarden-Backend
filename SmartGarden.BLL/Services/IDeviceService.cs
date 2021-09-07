using SmartGarden.BLL.DTO.Devices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public interface IDeviceService
	{
		Task<IEnumerable<DeviceDTO>> FindAllAsync();

		Task<DeviceDTO> FindByIdAsync(int id);

		Task<DeviceDTO> CreateAsync(CreateDeviceDTO deviceToCreate);

		Task<DeviceDTO> UpdateAsync(UpdateDeviceDTO deviceToUpdate);

		Task<DeviceDTO> DeleteAsync(int id);

		Task<bool> ExistLoginAsync(string login);
	}
}
