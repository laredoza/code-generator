using Microsoft.EntityFrameworkCore;
using Infrastructure.Core.SharedKernel;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Infrastructure.Infrastructure.Data.Repositories
{
    public class Repository<T,C> 
        where T : Entity 
        where C: DbContext, IUnitOfWork 
    {
        public readonly C _context;

        public IUnitOfWork UnitOfWork => _context;

        public Repository(C context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}