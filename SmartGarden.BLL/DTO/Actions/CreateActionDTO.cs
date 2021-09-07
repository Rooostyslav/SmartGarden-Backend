using SmartGarden.DAL.Entity.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Actions
{
	public class CreateActionDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Report { get; set; }

		[Required]
		public Status Status { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Errors { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime DateOfCreation { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime? DateOfCompletion { get; set; }

		[Required]
		public int PlantId { get; set; }
	}
}
