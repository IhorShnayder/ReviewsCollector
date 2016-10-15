using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReviewsCollector.DataAccess.Repositories
{
    public class ReviewsRepository : BaseRepository, IReviewsRepository
    {
        public ReviewsRepository(IUnitOfWork unitOfWork, IDatabaseContext dbContext)
            : base(unitOfWork, dbContext)
        { }

        public IEnumerable<Review> GetAll(EntityStatusEnum? status = null)
        {
            Expression<Func<Review, bool>> statusFilter = item => true;

            if(status.HasValue)
            {
                statusFilter = item => item.Status == status.Value;
            }

            return _dbContext.Reviews.Where(statusFilter);
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
                entity.Status = review.Status;

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
