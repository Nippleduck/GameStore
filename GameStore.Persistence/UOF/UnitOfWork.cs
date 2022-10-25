using GameStore.Persistence.Context;
using GameStore.Persistence.Repositories;
using GameStore.Persistence.Repositories.Interfaces;

namespace GameStore.Persistence.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context) => this.context = context;

        private readonly ApplicationDbContext context;

        private IGameRepository? games;
        private IGenreRepository? genres;

        public IGameRepository Games => games ??= new GameRepository(context);
        public IGenreRepository Genres => genres ??= new GenreRepository(context);

        public async Task SaveChanges() => await context.SaveChangesAsync();
    }
}
