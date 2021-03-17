using SmartGarden.BLL.DTO.Shared;

namespace SmartGarden.BLL.DTO.Users
{
	public class CreateUserDTO : BaseDTO
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }
	}
}
