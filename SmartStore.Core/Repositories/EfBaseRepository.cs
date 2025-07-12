

using Microsoft.EntityFrameworkCore;
using SmartStore.Core.Entities;
using System.Linq.Expressions;

namespace SmartStore.Core.Repositories
{
    public class EfBaseRepository<TContext, TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>, new()
        where TContext : DbContext

    {
        protected TContext _context { get; }

        public EfBaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedTime = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(bool enableTracking = false,
            bool withDeleted = false,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().ToListAsync(); 
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
