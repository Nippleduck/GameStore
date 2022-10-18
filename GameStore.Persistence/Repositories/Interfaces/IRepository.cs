using GameStore.Domain.Interfaces;

namespace GameStore.Persistence.Repositories.Interfaces
{
    public interface IRepository<TEntity, TId> 
        where TEntity : class, IEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteByIdAsync(TId id);
        Task UpdateAsync(TEntity entity);
    }

    public interface IGuidRepository<TEntity> : IRepository<TEntity, Guid> 
        where TEntity : class, IEntity<Guid>
    {

    }
}
