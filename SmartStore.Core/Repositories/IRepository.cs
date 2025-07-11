

using SmartStore.Core.Entities;

namespace SmartStore.Core.Repositories
{
    public interface IRepository <TEntity , TId> where TEntity : Entity <TId>, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?>GetByIdAsync(TId id);   

        Task<TEntity>AddAsync(TEntity entity);

        Task<TEntity?>UpdateAsync(TEntity entity);

        Task<TEntity?>DeleteAsync(TEntity entity);
   
    }
}
