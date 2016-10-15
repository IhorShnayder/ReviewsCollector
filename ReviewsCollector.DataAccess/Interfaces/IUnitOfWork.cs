namespace ReviewsCollector.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IReviewsRepository Reviews { get; }
    }
}
