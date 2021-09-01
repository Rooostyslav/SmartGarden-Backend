using Microsoft.EntityFrameworkCore;
using SmartGarden.DAL.Entity;

namespace SmartGarden.DAL.EF
{
	public class SmartGardenContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Garden> Gardens { get; set; }
		public DbSet<Plant> Plants { get; set; }
		public DbSet<Action> Actions { get; set; }
		public DbSet<Resource> Resources { get; set; }

		public SmartGardenContext(DbContextOptions<SmartGardenContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
