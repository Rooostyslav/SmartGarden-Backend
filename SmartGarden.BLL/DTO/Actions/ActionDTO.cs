using SmartGarden.BLL.DTO.Plants;
using SmartGarden.BLL.DTO.Shared;
using System;

namespace SmartGarden.BLL.DTO.Actions
{
	public class ActionDTO : BaseDTO
	{
		public DateTime Date { get; set; }

		public bool Status { get; set; }

		public int PlantId { get; set; }

		public PlantDTO Plant { get; set; }
	}
}
