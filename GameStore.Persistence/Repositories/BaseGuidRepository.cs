using GameStore.Persistence.Repositories.Interfaces;
using GameStore.Persistence.Context;
using GameStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.Repositories
{
    public abstract class BaseGuidRepository<TEntity> : IGuidRepository<TEntity>
        where TEntity : class, IEntity<Guid>
    {
        protected BaseGuidRepository(ApplicationDbContext context) => this.context = context;

        protected readonly ApplicationDbContext context;
        protected DbSet<TEntity> Entities => context.Set<TEntity>();    
        
        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var entity = await Entities.FindAsync(id);

            if (entity is null) return false;

            Entities.Remove(entity);

            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }
    }
}
