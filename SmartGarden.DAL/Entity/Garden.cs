using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarden.DAL.Entity
{
	[Table("Gardens")]
	public class Garden
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string SoilType { get; set; }

		[Required]
		[Column(Order = 5)]
		public double Square { get; set; }

		[Column(Order = 6)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string GPSCoordinates { get; set; }

		[Column(Order = 7)]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime DateOfCreation { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<Plant> Plants { get; set; }

		public ICollection<Resource> Resources { get; set; }

		public Garden()
		{
			Plants = new Collection<Plant>();
			Resources = new Collection<Resource>();
		}
	}
}
