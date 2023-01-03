using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Core.SharedKernel
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}