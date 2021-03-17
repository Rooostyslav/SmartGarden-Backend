using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.DTO.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartGarden.BLL.DTO.Users
{
	public class UserDTO : BaseDTO
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public ICollection<GardenDTO> Gardens { get; set; }

		public UserDTO()
		{
			Gardens = new Collection<GardenDTO>();
		}
	}
}
