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
			CreateMap<CreateUserDTO, User>();
			CreateMap<User, ViewUserDTO>();

			CreateMap<Garden, GardenDTO>().ReverseMap();
			CreateMap<CreateGardenDTO, Garden>();
			CreateMap<Garden, ViewGardenDTO>();

			CreateMap<Plant, PlantDTO>().ReverseMap();
			CreateMap<CreatePlantDTO, Plant>();
			CreateMap<Plant, ViewPlantDTO>();

			CreateMap<Action, ActionDTO>().ReverseMap();
			CreateMap<CreateActionDTO, Action>();
			CreateMap<UpdateActionDTO, Action>();
			CreateMap<Action, ViewActionDTO>();

			CreateMap<Resource, ResourceDTO>().ReverseMap();
			CreateMap<CreateResourceDTO, Resource>();
			CreateMap<Resource, ViewResourceDTO>();
		}
	}
}
