using SmartGarden.DAL.Entity.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Actions")]
	public class Action
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Report { get; set; }

		[Required]
		[Column(Order = 4)]
		public Status Status { get; set; }

		[Required]
		[Column(Order = 5)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Errors { get; set; }

		[Required]
		[Column(Order = 6)]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime DateOfCreation { get; set; }

		[Required]
		[Column(Order = 7)]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime? DateOfCompletion { get; set; }

		[ForeignKey("Plant")]
		[Column(Order = 8)]
		public int PlantId { get; set; }

		public Plant Plant { get; set; }
	}
}
