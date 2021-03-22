﻿using AutoMapper;
using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Interfaces;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			userRepository = unitOfWork.Users;
			this.mapper = mapper;
		}

		public async Task CreateAsync(CreateUserDTO userToCreate)
		{
			var user = mapper.Map<User>(userToCreate);
			await userRepository.AddAsync(user);
			await unitOfWork.SaveAsync();
		}

		public async Task<UserDTO> FindUserAsync(Login login)
		{
			var users = await userRepository
				.FindWithIncludesAsync(u => u.Email.ToLower() == login.Email.ToLower()
				 && u.Password == login.Password);

			var user = users.FirstOrDefault();
			return mapper.Map<UserDTO>(user);
		}

		public async Task<IEnumerable<ViewUserDTO>> FindAllUsersAsync()
		{
			var users = await userRepository.FindWithIncludesAsync(null);
			return mapper.Map<IEnumerable<ViewUserDTO>>(users);
		}
	}
}