using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Resources")]
	public class Resource : BaseEntity
	{
		public int Amount { get; set; }

		public int GardenId { get; set; }

		public Garden Garden { get; set; }
	}
}
