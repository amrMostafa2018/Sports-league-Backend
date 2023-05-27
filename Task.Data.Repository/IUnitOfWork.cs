using System.Threading.Tasks;

namespace Task.Data.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task<int> SaveChangesAsync();
        void Commit();
        void Rollback();
    }
}