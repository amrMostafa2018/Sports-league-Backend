using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task.Shared.Security
{
    public interface IApplicationIdentityDbContext 
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
