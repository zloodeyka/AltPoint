using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
	public class ClientsContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Child> Children { get; set; }
		public DbSet<Communication> Communications { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Passport> Passports { get; set; }

		public string DbPath { get; }

		public ClientsContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = System.IO.Path.Join(path, "blogging.db");
		}

		// The following configures EF to create a Sqlite database file in the
		// special "local" folder for your platform.
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
    }
}
