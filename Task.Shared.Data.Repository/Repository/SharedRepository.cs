

using Task.Shared.Data.Repository;
using Tasl.Data.Repository;

namespace Nafes.CrossCutting.Data.Repository
{
    public class SharedRepository<T, TK> : EFRepository<T, TK>, ISharedRepository<T, TK> where T : class
    {
        public SharedRepository(TaskSharedDbContext context) : base(context)
        {
        }
    }
}
