using AutoMapper;
using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Infrastructure;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<User> _users;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_users = unitOfWork.Users;
			_mapper = mapper;
		}

		public async Task<UserDTO> FindAsync(Login login)
		{
			login.Email = login.Email.ToLower();
			login.Password = HashAlgorithm.CreateMD5(login.Password);

			var user = await _users.GetFirstOrDefaultAsync(
				u => u.Email == login.Email &&
				u.HashedPassword == login.Password);

			return _mapper.Map<UserDTO>(user);
		}

		public async Task<IEnumerable<UserDTO>> FindAllAsync()
		{
			var users = await _users.GetAllAsync();
			return _mapper.Map<IEnumerable<UserDTO>>(users);
		}

		public async Task<UserDTO> FindByIdAsync(int userId)
		{
			var user = await _users.GetByIdAsync(userId);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> CreateAsync(CreateUserDTO userToCreate)
		{
			var user = _mapper.Map<User>(userToCreate);
			user.Email = user.Email.ToLower();
			user.HashedPassword = HashAlgorithm.CreateMD5(userToCreate.Password);

			var created = await _users.InsertAsync(user);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<UserDTO>(created);
		}

		public async Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate)
		{
			var user = await _users.GetByIdAsync(userToUpdate.Id);
			user = _mapper.Map(userToUpdate, user);
			user.HashedPassword = HashAlgorithm.CreateMD5(userToUpdate.Password);

			var updated = await _users.UpdateAsync(user);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<UserDTO>(updated);
		}

		public async Task<UserDTO> DeleteAsync(int id)
		{
			var deleted = await _users.DeleteAsync(id);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<UserDTO>(deleted);
		}

		public async Task<bool> ExistEmailAsync(string email)
		{
			email = email.ToLower();
			var user = await _users.GetFirstOrDefaultAsync(u => u.Email == email);
			return user != null;
		}
	}
}
