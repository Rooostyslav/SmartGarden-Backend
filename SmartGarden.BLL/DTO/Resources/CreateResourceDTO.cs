using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Resources
{
	public class CreateResourceDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Type { get; set; }

		[Required]
		public double Amount { get; set; }

		[Required]
		public double Maximum { get; set; }
	
		[Required]
		public int GardenId { get; set; }
	}
}
