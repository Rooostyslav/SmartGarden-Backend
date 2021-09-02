using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Devices")]
	public class Device
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
		public bool IsActive { get; set; }

		[Required]
		[Column(Order = 4)]
		public string Login { get; set; }

		[Required]
		[Column(Order = 5)]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string HashedPassword { get; set; }

		[ForeignKey("Garden")]
		[Column(Order = 6)]
		public int GardenId { get; set; }

		public Garden Garden { get; set; }
	}
}
