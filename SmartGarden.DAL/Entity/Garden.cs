using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Gardens")]
	public class Garden : BaseEntity
	{
		public string Description { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<Plant> Plants { get; set; }

		public ICollection<Resource> Resources { get; set; }

		public Garden()
		{
			Plants = new Collection<Plant>();
			Resources = new Collection<Resource>();
		}
	}
}
