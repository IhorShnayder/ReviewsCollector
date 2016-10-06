using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.Domain.Interfaces;

namespace ReviewsCollector.DataAccess.Repositories
{
    public class UnitOfWork
    {
        private IDatabaseContext _dbContext;
        private IReviewsRepository _reviews;
        public UnitOfWork(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UnitOfWork()
        {

        }

        internal IDatabaseContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public IReviewsRepository Reviews
        {
            get
            {
                if (_reviews == null)
                    _reviews = new ReviewsRepository(this);
                return _reviews;
            }
        }
    }
}
