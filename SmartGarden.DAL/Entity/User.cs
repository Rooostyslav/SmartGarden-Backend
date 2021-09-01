using SmartGarden.DAL.Entity.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Users")]
	public class User
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Text)]
		public string SecondName { get; set; }

		[Required]
		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[Column(Order = 5)]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string HashedPassword { get; set; }

		[Required]
		[Column(Order = 6)]
		public Role Role { get; set; }

		public ICollection<Garden> Gardens { get; set; }

		public User()
		{
			Gardens = new Collection<Garden>();
		}
	}
}
