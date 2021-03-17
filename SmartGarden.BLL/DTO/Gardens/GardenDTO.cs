using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.DTO.Resources;
using SmartGarden.BLL.DTO.Shared;
using SmartGarden.BLL.DTO.Users;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartGarden.BLL.DTO.Gardens
{
	public class GardenDTO : BaseDTO
	{
		public string Description { get; set; }

		public int UserId { get; set; }

		public UserDTO User { get; set; }

		public ICollection<PlantDTO> Plants { get; set; }

		public ICollection<ResourceDTO> Resources { get; set; }

		public GardenDTO()
		{
			Plants = new Collection<PlantDTO>();
			Resources = new Collection<ResourceDTO>();
		}
	}
}
