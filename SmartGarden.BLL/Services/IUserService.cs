using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public interface IUserService
	{
		Task<IEnumerable<UserDTO>> FindAllAsync();

		Task<UserDTO> FindAsync(Login login);

		Task<UserDTO> FindByIdAsync(int id);

		Task<UserDTO> CreateAsync(CreateUserDTO userToCreate);

		Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate);

		Task<UserDTO> DeleteAsync(int id);

		Task<bool> ExistEmailAsync(string email);
	}
}
