using SmartGarden.BLL.Validations.Users;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Users
{
	public class CreateUserDTO
	{
		[Required(ErrorMessage = "Required field.")]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Required field.")]
		[StringLength(50, MinimumLength = 3)]
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
		public int Role { get; set; }
	}
}
