using SmartGarden.BLL.DTO.Shared;

namespace SmartGarden.BLL.DTO.Users
{
	public class ViewUserDTO : BaseDTO
	{
		public string Email { get; set; }

		public string Role { get; set; }
	}
}
