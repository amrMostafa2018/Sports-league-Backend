using Task.Data.Repository;

namespace Task.Shared.Data.Repository
{
    public interface ISharedRepository<T, K> : IRepository<T, K> where T : class
    {
    }
}
