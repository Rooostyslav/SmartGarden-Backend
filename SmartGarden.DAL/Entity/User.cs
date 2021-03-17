using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Users")]
	public class User : BaseEntity
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public ICollection<Garden> Gardens { get; set; }

		public User()
		{
			Gardens = new Collection<Garden>();
		}
	}
}
