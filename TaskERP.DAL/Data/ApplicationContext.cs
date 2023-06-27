
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

				//Seeding a  'Administrator' role to AspNetRoles table
				modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
				modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "User", NormalizedName = "USER".ToUpper() });


				//a hasher to hash the password before seeding the user to the db
				var hasher = new PasswordHasher<IdentityUser>();


				//Seeding the User to AspNetUsers table
				modelBuilder.Entity<IdentityUser>().HasData(
					new IdentityUser
					{
						Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
						UserName = "Admin",
						NormalizedUserName = "ADMIN",
						Email = "Admin@admin.com",
						PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
					}
				);


				//Seeding the relation between our user and role to AspNetUserRoles table
				modelBuilder.Entity<IdentityUserRole<string>>().HasData(
					new IdentityUserRole<string>
					{
						RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
						UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
					}
				);


			}

			modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Name = "English" });
			modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Name = "Italian" });
			modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Name = "French" });
			modelBuilder.Entity<Language>().HasData(new Language { Id = 4, Name = "Spanish" });
			modelBuilder.Entity<Language>().HasData(new Language { Id = 5, Name = "German" });

			modelBuilder.Entity<Leveles>().HasData(new Leveles { Id = 1, Name = "A1" });
			modelBuilder.Entity<Leveles>().HasData(new Leveles { Id = 2, Name = "A2" });
			modelBuilder.Entity<Leveles>().HasData(new Leveles { Id = 3, Name = "B1" });
			modelBuilder.Entity<Leveles>().HasData(new Leveles { Id = 4, Name = "B2" });
			modelBuilder.Entity<Leveles>().HasData(new Leveles { Id = 5, Name = "C1" });
			modelBuilder.Entity<Leveles>().HasData(new Leveles { Id = 6, Name = "C2" });


			modelBuilder.Entity<Account>().HasData(new Account { Id = 1, Name = "TE Data" });
			modelBuilder.Entity<Account>().HasData(new Account { Id = 2, Name = "Telecom Egypt" });


			modelBuilder.Entity<LineOfBusiness>().HasData(new LineOfBusiness { Id = 1, Name = "Basic" ,AccountId=1});
			modelBuilder.Entity<LineOfBusiness>().HasData(new LineOfBusiness { Id = 2, Name = "Technical Support", AccountId=1});
			modelBuilder.Entity<LineOfBusiness>().HasData(new LineOfBusiness { Id = 3, Name = "Inbound", AccountId=2});
			modelBuilder.Entity<LineOfBusiness>().HasData(new LineOfBusiness { Id = 4, Name = "Outbound", AccountId=2});






		}
	}
}
