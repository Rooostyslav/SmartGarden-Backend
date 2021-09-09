using SmartGarden.BLL.Validations.Users;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Users
{
	public class CreateUserDTO
	{
		[Required(ErrorMessage = "Required field.")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum {2} characters, maximum {1} characters.")]
		[RegularExpression(@"^[A-Z]", ErrorMessage = "Capitalize first character.")]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Required field.")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum {2} characters, maximum {1} characters.")]
		[RegularExpression(@"^[A-Z]", ErrorMessage = "Capitalize first character.")]
		[DataType(DataType.Text)]
		public string SecondName { get; set; }

		[Required(ErrorMessage = "Required field.")]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		[ExistEmail(ErrorMessage = "Email already exist.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Required field.")]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Required field.")]
		[ExistRole(ErrorMessage = "Role does not exist.")]
		public int Role { get; set; }
	}
}
