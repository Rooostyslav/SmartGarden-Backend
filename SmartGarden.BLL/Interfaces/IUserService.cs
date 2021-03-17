using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.DTO.Users;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> FindUserAsync(Login login);

		Task CreateAsync(CreateUserDTO userToCreate);
	}
}
