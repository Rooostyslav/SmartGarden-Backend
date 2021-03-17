using System.ComponentModel.DataAnnotations;

namespace SmartGarden.DAL.Entity
{
	public abstract class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}