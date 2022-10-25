using GameStore.Persistence.Repositories.Interfaces;

namespace GameStore.Persistence.UOF
{
    public interface IUnitOfWork
    {
        IGameRepository Games { get; }
        IGenreRepository Genres { get; }
        Task SaveChanges();
    }
}
