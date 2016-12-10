using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MrFixIt.Models
{
    //MrFixItContext is extending IdentityDbContext of the ApplicationUser
    public class MrFixItContext : IdentityDbContext<ApplicationUser>
    {
        //setting up an empty MrFixItContext Constructor for referenceing the context and database
        public MrFixItContext()
        {
        }
        //Each DbSet to set a table in database. When using Migration we don't actually need public virtual DbSet(for when we create database first)
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Worker> Workers { get; set; }

        //**need the override 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MrFixIt;integrated security=True");
        }

        //This tells Code that the connection string to use for MrFixItContext should be loaded from the Configuration(appsettings.json) & startup file.
        //The context represents a connection with the database, allowing us to query and save data.
        public MrFixItContext(DbContextOptions<MrFixItContext> options)
            : base(options)
        {
        }

        //We use OnModelCreating to create new tables in Database. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //Next we can add migration & update the database
    }
}