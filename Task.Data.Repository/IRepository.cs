using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Task.Data.Repository
{
    public interface IRepository<T, in K> where T : class
    {
        Task<T> Add(T item);

        Task<T> AddThenDeAttach(T item);

        Task<List<T>> AddRange(List<T> items);

        Task<bool> Update(T item);

        Task<List<T>> UpdateRange(List<T> items);

        Task<bool> DeleteById(K id);

        Task<bool> Delete(T item);
        Task<bool> DeleteFromDB(T item);
        Task<int> DeleteRangeAsync(List<T> entities);
        Task<T> GetById(K id);
        IQueryable<T> GetAll(bool includeSoftDeleted = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool disableTracking = true, bool includeSoftDeleted = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includes);

        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false);

        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includesPaths);
        Task<T> GetById(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params Expression<Func<T, object>>[] includes);

        void SaveChanges();
        System.Threading.Tasks.Task SaveChangesAsync();
        IDatabaseTransaction BeginTransaction();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includes);

        Task<bool> Any(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false);
        System.Threading.Tasks.Task ExexuteAsTransaction(Func<System.Threading.Tasks.Task> action);
    }
}
