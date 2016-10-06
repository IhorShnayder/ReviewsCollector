using ReviewsCollector.Domain.Entities;
using System.Data.Entity;

namespace ReviewsCollector.DataAccess.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Review> Reviews { get; set; }
        int SaveChanges();
    }
}
