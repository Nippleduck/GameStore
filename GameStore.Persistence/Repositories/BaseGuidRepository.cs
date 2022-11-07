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
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (entity is null) return false;

            context.Set<TEntity>().Remove(entity);

            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
    }
}
