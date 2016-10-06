using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsCollector.DataAccess.Repositories
{
    public class ReviewsRepository : BaseRepository, IReviewsRepository
    {
        public ReviewsRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public IEnumerable<Review> GetAll()
        {
            return _dbContext.Reviews;
        }

        public Review GetById(int reviewId)
        {
            return _dbContext.Reviews.FirstOrDefault(e => e.Id == reviewId);
        }

        public bool Delete(int reviewId)
        {
            try
            {
                var entity = _dbContext.Reviews.FirstOrDefault(e => e.Id == reviewId);

                if (entity == null)
                    return false;

                _dbContext.Reviews.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Review Add(Review review)
        {
            try
            {
                var entity = _dbContext.Reviews.Add(review);
                _dbContext.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }

        }

        public Review Update(Review review)
        {
            try
            {
                var entity = _dbContext.Reviews.FirstOrDefault(e => e.Id == review.Id);

                if (entity == null)
                    return null;

                entity.Name = review.Name;
                entity.Description = review.Description;
                entity.Content = review.Content;

                _dbContext.SaveChanges();

                return entity;
            }
            catch
            {
                return null;
            }
        }
    }
}
