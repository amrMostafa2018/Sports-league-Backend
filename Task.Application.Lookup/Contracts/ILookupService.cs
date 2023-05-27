using Nafes.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Task.Application.Lookups.Contracts
{
    public interface ILookupService<T> where T : class, ILookup
    {
        List<T> GetLookupItems(bool includeDeleted = false);
        Task<T> GetLookupItemById(int id);
        List<T> GetLookupItemsByParentId(string parentKey, int parentId, bool includeDeleted = false);
        Task<T> GetLookupItemByName(string name);
    }
}