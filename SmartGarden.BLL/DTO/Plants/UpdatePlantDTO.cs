using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Plants
{
	public class UpdatePlantDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Type { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string GPSCoordinates { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime LandingDate { get; set; }

		[Required]
		public int GardenId { get; set; }
	}
}
