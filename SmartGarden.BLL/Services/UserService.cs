using AutoMapper;
using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Infrastructure;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<User> _users;
		private readonly IMapper mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			_users = unitOfWork.Users;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreateUserDTO userToCreate)
		{
			var user = mapper.Map<User>(userToCreate);
			user.Email = user.Email.ToLower();

			HashAlgorithm hashAlgoritm = new HashAlgorithm();
			user.HashedPassword = hashAlgoritm.CreateMD5(userToCreate.Password);
			
			await _users.InsertAsync(user);
			await unitOfWork.SaveAsync();
		}

		public async Task<UserDTO> FindUserAsync(Login login)
		{
			HashAlgorithm hashAlgoritm = new HashAlgorithm();
			var passwordMD5 = hashAlgoritm.CreateMD5(login.Password);

			var users = await _users.GetAllAsync(
				u => u.Email.ToLower() == login.Email.ToLower() &&
				u.HashedPassword == passwordMD5);

			var user = users.FirstOrDefault();
			return mapper.Map<UserDTO>(user);
		}

		public async Task<IEnumerable<ViewUserDTO>> FindAllUsersAsync()
		{
			var users = await _users.GetAllAsync();
			return mapper.Map<IEnumerable<ViewUserDTO>>(users);
		}

		public async Task<ViewUserDTO> FindUserByIdAsync(int userId)
		{
			var user = await _users.GetByIdAsync(userId);
			return mapper.Map<ViewUserDTO>(user);
		}

		public async Task<bool> ExistEmailAsync(string email)
		{
			var users = await _users
				.GetAllAsync(u => u.Email == email.ToLower());
			return users.Count() > 0 ? true : false;
		}
	}
}
