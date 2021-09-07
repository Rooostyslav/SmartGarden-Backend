using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Devices
{
	public class CreateDeviceDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		public bool IsActive { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public int GardenId { get; set; }
	}
}
