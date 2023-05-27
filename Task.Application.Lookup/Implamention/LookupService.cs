using Nafes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Application.Lookups.Contracts;
using Task.Shared.Data.Repository;

namespace Task.Application.Lookups.Implamention
{
    public class LookupService<T> : ILookupService<T> where T : class, ILookup
    {
        private ISharedRepository<T, int> _repository;

        public LookupService(ISharedRepository<T, int> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetLookupItemById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<T> GetLookupItemByName(string name)
        {
            return await _repository.FindOneAsync(x => x.NameAr == name);
        }
        public List<T> GetLookupItems(bool includeDeleted = false)
        {
            var items = _repository.Find(x => x.IsVisible && (includeDeleted || x.IsDeleted == false));
            return items.ToList();
        }

        public List<T> GetLookupItemsByParentId(string parentKey, int parentId, bool includeDeleted = false)
        {
            IQueryable<T> items = _repository.Find(x => x.IsVisible && (includeDeleted ? true : x.IsDeleted == false));

        
            return items.ToList();
        }
    }
}