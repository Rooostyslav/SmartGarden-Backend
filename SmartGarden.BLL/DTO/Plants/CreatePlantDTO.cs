using SmartGarden.BLL.DTO.Shared;

namespace SmartGarden.BLL.DTO.Plants
{
	public class CreatePlantDTO : BaseDTO
	{
		public string Description { get; set; }

		public string Location { get; set; }

		public int GardenId { get; set; }
	}
}
