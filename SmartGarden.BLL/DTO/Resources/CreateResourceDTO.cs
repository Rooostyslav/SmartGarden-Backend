using SmartGarden.BLL.DTO.Shared;

namespace SmartGarden.BLL.DTO.Resources
{
	public class CreateResourceDTO : BaseDTO
	{
		public int Amount { get; set; }

		public int GardenId { get; set; }
	}
}
