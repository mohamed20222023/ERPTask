
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskERP.DAL.Models;
using TaskERP.Models;

namespace TaskERP.Data
{
	public class ApplicationContext : IdentityDbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<LineOfBusiness> LineOfBusinesses { get; set; }
		public DbSet<Leveles> Leveles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			{
				base.OnModelCreating(modelBuilder);

				// Define a primary key for the IdentityUserLogin entity
				modelBuilder.Entity<IdentityUserLogin<string>>()
					.HasKey(l => new { l.LoginProvider, l.ProviderKey });
			}

		}
	}
}
