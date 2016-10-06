using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.Domain.Entities;
using System.Data.Entity;

namespace ReviewsCollector.DataAccess
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext() : base("AzureConnectionString")
        {

        }
        public DbSet<Review> Reviews { get; set; }
    }
}
