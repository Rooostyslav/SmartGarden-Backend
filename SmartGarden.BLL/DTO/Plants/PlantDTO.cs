using SmartGarden.BLL.DTO.Gardens;
using System;

namespace SmartGarden.BLL.DTO.Plants
{
	public class PlantDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public string Description { get; set; }

		public string GPSCoordinates { get; set; }

		public DateTime LandingDate { get; set; }

		public int GardenId { get; set; }

		public GardenDTO Garden { get; set; }
	}
}
