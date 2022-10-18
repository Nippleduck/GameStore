using GameStore.Persistence.Repositories.Interfaces;

namespace GameStore.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGameRepository Games { get; }
        IGenreRepository Genres { get; }
        Task SaveChanges();
    }
}
