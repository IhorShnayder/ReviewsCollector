using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.Domain.Interfaces;

namespace ReviewsCollector.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected IDatabaseContext _dbContext;
        protected IUnitOfWork _unitOfWork;
        
        public BaseRepository(IUnitOfWork unitOfWork, IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

    }
}
