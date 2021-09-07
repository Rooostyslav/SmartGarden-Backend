using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Gardens
{
	public class UpdateGardenDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Address { get; set; }

		[StringLength(50)]
		[DataType(DataType.Text)]
		public string SoilType { get; set; }

		[Required]
		public double Square { get; set; }

		[StringLength(50)]
		[DataType(DataType.Text)]
		public string GPSCoordinates { get; set; }

		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime DateOfCreation { get; set; }

		[Required]
		public int UserId { get; set; }
	}
}
