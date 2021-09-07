using SmartGarden.BLL.DTO.Plants;
using SmartGarden.DAL.Entity.Common;
using System;

namespace SmartGarden.BLL.DTO.Actions
{
	public class ActionDTO
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string Report { get; set; }

		public Status Status { get; set; }

		public string Errors { get; set; }

		public DateTime DateOfCreation { get; set; }

		public DateTime? DateOfCompletion { get; set; }

		public int PlantId { get; set; }

		public PlantDTO Plant { get; set; }
	}
}
