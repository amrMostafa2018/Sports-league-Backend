namespace Task.Data.Repository
{
    public interface IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}