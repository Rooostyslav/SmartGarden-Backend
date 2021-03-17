using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Plants")]
	public class Plant : BaseEntity
	{
		public string Description { get; set; }

		public string Location { get; set; }

		public int GardenId { get; set; }

		public Garden Garden { get; set; }

		public ICollection<Action> Actions { get; set; }

		public Plant()
		{
			Actions = new Collection<Action>();
		}
	}
}
