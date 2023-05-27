using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task.Data.Repository;

namespace Tasl.Data.Repository
{
    public class EFRepository<T, TK> : IRepository<T, TK> where T : class
    {
        protected DbContext _context;
        private DbSet<T> _entitySet;

        public EFRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entitySet = _context.Set<T>();
        }

        public async Task<T> Add(T item)
        {
            await _entitySet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<T> AddThenDeAttach(T item)
        {
            await _entitySet.AddAsync(item);
            await _context.SaveChangesAsync();
            _context.Entry(item).State = EntityState.Detached;
            return item;
        }

        public async Task<List<T>> AddRange(List<T> items)
        {
            try
            {
                await _entitySet.AddRangeAsync(items);
                await _context.SaveChangesAsync();
                items.ForEach(item => _context.Entry(item).State = EntityState.Detached);


            }
            catch (Exception ex)
            {

            }
            return items;
        }

        public async Task<bool> Delete(T item)
        {
            if (item is ISoftDelete)
            {
                return await SoftDelete(item);
            }
            else
            {
                _entitySet.Attach(item);
                _entitySet.Remove(item);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { }
                return true;
            }
        }

        public async Task<bool> DeleteFromDB(T item)
        {
            _entitySet.Attach(item);
            _entitySet.Remove(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }
            return true;
        }


        public async Task<bool> DeleteById(TK id)
        {
            var item = await _entitySet.FindAsync(id);
            if (item is ISoftDelete)
            {
                return await SoftDelete(item);
            }
            else
            {
                _entitySet.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<int> DeleteRangeAsync(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }
        private async Task<bool> SoftDelete(T item)
        {
            var dbEntry = _entitySet.Attach(item);
            dbEntry.CurrentValues[nameof(ISoftDelete.DeleteDate)] = DateTime.Now;
            dbEntry.CurrentValues[nameof(ISoftDelete.IsDeleted)] = true;
            return await Update(item);
        }

        public async Task<T> GetById(TK id)
        {
            var entity = await _entitySet.FindAsync(id);
            if (entity is null) return null;
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public async Task<T> GetById(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params Expression<Func<T, object>>[] includes)
        {
            var items = _entitySet.AsNoTracking().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    items = items.Include(include);
                }
            }
            return includeSoftDeleted ? await items.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(predicate) : await items.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll(bool includeSoftDeleted = false)
        {
            return includeSoftDeleted ? _entitySet.AsNoTracking().IgnoreQueryFilters() : _entitySet.AsNoTracking();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool disableTracking = true, bool includeSoftDeleted = false)
        {
            if (disableTracking)
                return includeSoftDeleted ? _entitySet.AsNoTracking().Where(predicate).IgnoreQueryFilters() : _entitySet.AsNoTracking().Where(predicate);

            return includeSoftDeleted ? _entitySet.IgnoreQueryFilters().Where(predicate) : _entitySet.Where(predicate);
        }

        public async Task<bool> Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(item).State = EntityState.Detached;
            return true;
        }
        public async Task<List<T>> UpdateRange(List<T> items)
        {
            _entitySet.UpdateRange(items);
            await _context.SaveChangesAsync();
            return items;
        }
       
        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includesPaths)
        {
            var items = _entitySet.AsNoTracking().AsQueryable();
            if (includesPaths != null)
            {
                foreach (var include in includesPaths)
                {
                    items = items.Include(include);
                }
            }
            return includeSoftDeleted ? await items.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(predicate) : await items.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

       

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includes)
        {
            var items = _entitySet.AsNoTracking().AsQueryable<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    items = items.Include(include);
                }
            }
            return includeSoftDeleted ? items.IgnoreQueryFilters().Where(predicate) : items.Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includes)
        {
            IQueryable<T> items = new List<T>().AsQueryable();
            try
            {
                items = _entitySet.AsNoTracking().AsQueryable<T>();

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        items = items.Include(include);
                    }
                }
                return includeSoftDeleted ? await items.IgnoreQueryFilters().Where(predicate).ToListAsync() : await items.Where(predicate).ToListAsync();

            }
            catch (Exception exception)
            {
                IEnumerable<T> items1 = new List<T>();
                if (items.GetEnumerator().Current == null)
                    return items1;
                return items1;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false)
        {
            var items = _entitySet.AsNoTracking().AsQueryable();
            return includeSoftDeleted ? await items.AsNoTracking().IgnoreQueryFilters().CountAsync(predicate) : await items.AsNoTracking().CountAsync(predicate);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false)
        {
            var items = _entitySet.AsNoTracking().AsQueryable();
            return includeSoftDeleted ? await items.AsNoTracking().IgnoreQueryFilters().AnyAsync(predicate) : await items.AsNoTracking().AnyAsync(predicate);
        }
        public async System.Threading.Tasks.Task ExexuteAsTransaction(Func<System.Threading.Tasks.Task> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {

                    await action();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });

        }

 
    }
}
