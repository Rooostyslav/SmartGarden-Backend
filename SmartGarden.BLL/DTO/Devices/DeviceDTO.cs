using SmartGarden.BLL.DTO.Gardens;

namespace SmartGarden.BLL.DTO.Devices
{
	public class DeviceDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsActive { get; set; }

		public string Login { get; set; }

		public string HashedPassword { get; set; }

		public int GardenId { get; set; }

		public GardenDTO Garden { get; set; }
	}
}
