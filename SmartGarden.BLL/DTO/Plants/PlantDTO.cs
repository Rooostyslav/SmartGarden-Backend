using SmartGarden.BLL.DTO.Actions;
using SmartGarden.BLL.DTO.Gardens;
using SmartGarden.BLL.DTO.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartGarden.BLL.DTO.Plants
{
	public class PlantDTO : BaseDTO
	{
		public string Description { get; set; }

		public string Location { get; set; }

		public int GardenId { get; set; }

		public GardenDTO Garden { get; set; }

		public ICollection<ActionDTO> Actions { get; set; }

		public PlantDTO()
		{
			Actions = new Collection<ActionDTO>();
		}
	}
}
