using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.DTO.Shared;

namespace SmartGarden.BLL.DTO.Resources
{
	public class ResourceDTO : BaseDTO
	{
		public int Amount { get; set; }

		public int GardenId { get; set; }

		public GardenDTO Garden { get; set; }
	}
}
