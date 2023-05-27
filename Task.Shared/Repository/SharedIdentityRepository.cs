using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Shared.Security;
using Tasl.Data.Repository;

namespace Task.Shared.Repository
{
    public class SharedIdentityRepository<T, TK> : EFRepository<T, TK>, ISharedIdentityRepository<T, TK> where T : class
    {
        public SharedIdentityRepository(ApplicationIdentityDbContext context) : base(context)
        {

        }
    }
}
