using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Resources")]
	public class Resource
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Type { get; set; }

		[Required]
		[Column(Order = 4)]
		public double Amount { get; set; }

		[Required]
		[Column(Order = 5)]
		public double Maximum { get; set; }

		[ForeignKey("Garden")]
		public int GardenId { get; set; }

		public Garden Garden { get; set; }
	}
}
