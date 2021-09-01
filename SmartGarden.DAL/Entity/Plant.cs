using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Plants")]
	public class Plant
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Type { get; set; }

		[Required]
		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Required]
		[Column(Order = 5)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string GPSCoordinates { get; set; }

		[Required]
		[Column(Order = 6)]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime LandingDate { get; set; }

		[ForeignKey("Garden")]
		public int GardenId { get; set; }

		public Garden Garden { get; set; }

		public ICollection<Action> Actions { get; set; }

		public Plant()
		{
			Actions = new Collection<Action>();
		}
	}
}
