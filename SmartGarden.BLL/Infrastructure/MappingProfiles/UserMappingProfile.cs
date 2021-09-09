using AutoMapper;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.DAL.Entity;

namespace SmartGarden.BLL.Infrastructure.MappingProfiles
{
	public class UserMappingProfile : Profile
	{
		public UserMappingProfile()
		{
			CreateMap<User, UserDTO>()
				.ForMember(dest => dest.FullName,
					opt => opt.MapFrom(u => string.Join(" ", u.FirstName, u.SecondName)))
				.ForMember(dest => dest.Role,
					opt => opt.MapFrom(u => u.Role.ToString().ToLower()));

			CreateMap<CreateUserDTO, User>();
			CreateMap<UpdateUserDTO, User>();
		}
	}
}
