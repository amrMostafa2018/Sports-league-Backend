using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Repository;

namespace Task.Shared.Repository
{
    public interface ISharedIdentityRepository<T, K> : IRepository<T, K> where T : class
    {

    }
}
