using GameStore.Common.Filtering.Models;
using GameStore.Domain.Entities;

namespace GameStore.Persistence.Repositories.Interfaces
{
    public interface IGameRepository : IGuidRepository<Game> 
    {
        Task<IEnumerable<Game>> GetAllWithFilter(GameFilter filter);
        Task<IEnumerable<Game>> GetAllWithDetails();
        Task<IEnumerable<Game>> GetAllByGenreId(Guid genreId);
        Task<Game?> GetByIdWithDetails(Guid id);
    }
}
