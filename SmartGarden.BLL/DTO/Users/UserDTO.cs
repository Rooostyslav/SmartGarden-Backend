using SmartGarden.DAL.Entity.Common;

namespace SmartGarden.BLL.DTO.Users
{
	public class UserDTO
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string Email { get; set; }

		public string HashedPassword { get; set; }

		public Role Role { get; set; }
	}
}
