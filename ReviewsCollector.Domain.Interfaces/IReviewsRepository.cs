using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Domain.Entities.Enums;
using System.Collections.Generic;

namespace ReviewsCollector.Domain.Interfaces
{
    public interface IReviewsRepository
    {
        IEnumerable<Review> GetAll(EntityStatusEnum? status = null);
        Review GetById(int reviewId);
        Review Add(Review review);
        Review Update(Review review);
        bool Delete(int reviewId); 
    }
}
