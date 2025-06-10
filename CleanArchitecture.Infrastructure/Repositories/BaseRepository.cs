using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.MarkAsUpdated();
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.MarkAsDeleted();
            _context.Remove(entity);
        }

        public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
