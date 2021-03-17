﻿using SmartGarden.BLL.DTO.Shared;
using System;

namespace SmartGarden.BLL.DTO.Actions
{
	public class UpdateActionDTO : BaseDTO
	{
		public DateTime Date { get; set; }

		public bool Status { get; set; }

		public int PlantId { get; set; }
	}
}
