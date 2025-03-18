using BMCore.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BMCore.Database.DatabaseContexts
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        #region Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //Newly added entities
        public DbSet<City> Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BranchEmployee> BranchEmployees { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            //Config of BranchEmployee
            modelBuilder.Entity<BranchEmployee>()
                .HasKey(be => be.Id);

            modelBuilder.Entity<BranchEmployee>()
                .HasOne(be => be.Employee)
                .WithMany(e => e.BranchEmployees)
                .HasForeignKey(be => be.EmployeeId);

            modelBuilder.Entity<BranchEmployee>()
                .HasOne(be => be.Branch)
                .WithMany(b => b.BranchEmployees)
                .HasForeignKey(be => be.BranchId);

            modelBuilder.Entity<BranchEmployee>()
                .HasOne(be => be.Role)
                .WithMany(r => r.BranchEmployees)
                .HasForeignKey(be => be.RoleId);
        }
    }
}