using AutoMapper;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.DAL.Entity;

namespace SmartGarden.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDTO>().ReverseMap();
			CreateMap<User, CreateUserDTO>();

			CreateMap<Garden, GardenDTO>().ReverseMap();
			CreateMap<Garden, CreateGardenDTO>();

			CreateMap<Plant, PlantDTO>().ReverseMap();
			CreateMap<Plant, CreatePlantDTO>();

			CreateMap<Action, ActionDTO>().ReverseMap();
			CreateMap<Action, CreateActionDTO>();
			CreateMap<Action, UpdateActionDTO>();

			CreateMap<Resource, ResourceDTO>().ReverseMap();
		}
	}
}
