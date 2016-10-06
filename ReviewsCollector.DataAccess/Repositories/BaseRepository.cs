using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.Domain.Interfaces;

namespace ReviewsCollector.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected IDatabaseContext _dbContext;
        protected UnitOfWork _unitOfWork;
        
        public BaseRepository(UnitOfWork unitOfWork)
        {
            _dbContext = unitOfWork.DbContext;
            _unitOfWork = unitOfWork;
        }

    }
}
