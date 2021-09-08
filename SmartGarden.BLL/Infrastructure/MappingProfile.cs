﻿using AutoMapper;
using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.DTO.Devices;
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
			CreateMap<User, UserDTO>()
				.ForMember(dest => dest.Role, opt => opt.MapFrom(u => u.Role.ToString().ToLower()));
			CreateMap<CreateUserDTO, User>();
			CreateMap<UpdateUserDTO, User>();

			CreateMap<Garden, GardenDTO>();
			CreateMap<CreateGardenDTO, Garden>();
			CreateMap<UpdateGardenDTO, Garden>();

			CreateMap<Plant, PlantDTO>();
			CreateMap<CreatePlantDTO, Plant>();
			CreateMap<UpdatePlantDTO, Plant>();

			CreateMap<Action, ActionDTO>();
			CreateMap<CreateActionDTO, Action>();
			CreateMap<UpdateActionDTO, Action>();

			CreateMap<Resource, ResourceDTO>();
			CreateMap<CreateResourceDTO, Resource>();
			CreateMap<UpdateResourceDTO, Resource>();

			CreateMap<Device, DeviceDTO>();
			CreateMap<CreateDeviceDTO, Device>();
			CreateMap<UpdateDeviceDTO, Device>();
		}
	}
}
