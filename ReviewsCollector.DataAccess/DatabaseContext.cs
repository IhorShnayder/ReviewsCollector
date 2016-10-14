using Microsoft.AspNet.Identity.EntityFramework;
using ReviewsCollector.DataAccess.Identity;
using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.DataAccess.Migrations;
using ReviewsCollector.Domain.Entities;
using System.Data.Entity;

namespace ReviewsCollector.DataAccess
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
    {
        public DatabaseContext() : base("AzureConnectionString")
        {

        }

        static DatabaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public DbSet<Review> Reviews { get; set; }
    }
}


