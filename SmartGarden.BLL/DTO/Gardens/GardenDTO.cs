using SmartGarden.BLL.DTO.Users;
using System;

namespace SmartGarden.BLL.DTO.Gardens
{
	public class GardenDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public string SoilType { get; set; }

		public double Square { get; set; }

		public string GPSCoordinates { get; set; }

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public UserDTO User { get; set; }
	}
}
