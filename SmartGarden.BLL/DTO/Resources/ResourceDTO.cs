using SmartGarden.BLL.DTO.Gardens;

namespace SmartGarden.BLL.DTO.Resources
{
	public class ResourceDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public double Amount { get; set; }

		public double Maximum { get; set; }

		public int GardenId { get; set; }

		public GardenDTO Garden { get; set; }
	}
}
